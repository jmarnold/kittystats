using System.Web.Script.Serialization;
using FubuMVC.Core.Content;
using FubuMVC.Core.View;
using HtmlTags;

namespace KittyStats.Web.Extensions
{
    public static class TagExtensions
    {
        public static HtmlTag ImageFor(this IFubuPage page, string path)
        {
			var url = page.Get<IContentRegistry>().ImageUrl(path);
            return new HtmlTag("img").Attr("src", url);
        }

        public static string ToJson(this object value)
        {
            return new JavaScriptSerializer().Serialize(value);
        }
    }
}