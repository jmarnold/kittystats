using System;
using FubuMVC.Core;
using FubuMVC.Spark;
using KittyStats.Domain;
using KittyStats.Web.Configuration;
using KittyStats.Web.Endpoints;
using KittyStats.Web.Models;

namespace KittyStats.Web
{
    public class KittyFubuRegistry : FubuRegistry
    {
        public KittyFubuRegistry()
        {
            IncludeDiagnostics(true);

            Applies
                .ToThisAssembly()
                .ToAssemblyContainingType<Kitty>();

            Actions.IncludeClassesSuffixedWithController();

            this.ApplyEndpointConventions(typeof (EndpointMarker));

            Routes
                .HomeIs<DashboardEndpoint>(e => e.Get(new DashboardRequestModel()));

            this.UseSpark();

            Views
                .TryToAttachWithDefaultConventions();

            HtmlConvention<KittyHtmlConventions>();

            StringConversions(x =>
                                  {
                                      x.IfPropertyMatches(p => p.PropertyType == typeof (DateTime) && p.Name.Contains("Date"))
                                          .ConvertBy(r => ((DateTime) r.RawValue).ToShortDateString());

                                      x.IfPropertyMatches(p => p.PropertyType == typeof(DateTime) && p.Name.Contains("Time"))
                                          .ConvertBy(r => ((DateTime)r.RawValue).ToString("MM/dd/yyyy hh:mm tt"));
                                  });
        }
    }
}