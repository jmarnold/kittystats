using System;
using FubuMVC.Core.UI;

namespace KittyStats.Web.Configuration
{
    public class KittyHtmlConventions : HtmlConventionRegistry
    {
        public KittyHtmlConventions()
        {
            Editors
                .If(a => a.Accessor.PropertyType == typeof(DateTime) && a.Accessor.Name.Contains("Date"))
                .Modify(t => t.AddClass("date"));

            Editors
                .If(a => a.Accessor.Name.Contains("Id"))
                .Modify(t => t.Attr("type", "hidden"));

            Editors
                .Always
                .Modify((r, t) => t.Attr("id", r.ElementId));
        }
    }
}