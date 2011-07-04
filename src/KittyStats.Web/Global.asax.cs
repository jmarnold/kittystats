using System;
using System.Web.Routing;
using Bottles;
using FubuMVC.Core;
using FubuMVC.StructureMap;
using KittyStats.Configuration;
using StructureMap;

namespace KittyStats.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FubuApplication
                .For<KittyFubuRegistry>()
                .StructureMap(() =>
                                  {
                                      ObjectFactory.Initialize(x => x.AddRegistry<CoreRegistry>());
                                      return ObjectFactory.Container;
                                  })
                .Bootstrap(RouteTable.Routes);

            PackageRegistry.AssertNoFailures();
        }
    }
}