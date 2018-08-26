using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {

        public static IHtmlString AjaxAdminLTEActionLink(this AjaxHelper ajaxHelper,
            string linkText,
            string actionName,
            string controllerName,
            AjaxOptions ajaxOptions,
            string LoadingElementId,
            IDictionary<string, object> buttonAttributes = null,
            string Image = "~/Images/progress.gif"
        )
        {
            var targetUrl = UrlHelper.GenerateUrl(null, actionName, null, null, ajaxHelper.RouteCollection, ajaxHelper.ViewContext.RequestContext, true);
            return MvcHtmlString.Create(ajaxHelper.GenerateLink(linkText, targetUrl, ajaxOptions ?? new AjaxOptions(), null,LoadingElementId,buttonAttributes,Image));
        }

        private static string GenerateLink(
            this AjaxHelper ajaxHelper,
            string linkText,
            string targetUrl,
            AjaxOptions ajaxOptions,
            IDictionary<string, object> htmlAttributes,
            string LoadingElementId,
            IDictionary<string, object> buttonAttributes = null,
            string Image = "~/Images/progress.gif"
        )
        {
            var a = new TagBuilder("a")
            {
                InnerHtml = linkText
            };

            TagBuilder span = new TagBuilder("span");
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", Image);
            img.MergeAttribute("width", "20");
            span.MergeAttribute("id", LoadingElementId);
            span.MergeAttribute("class", "center");
            span.MergeAttribute("style", "display:none; padding-left:10px");

            if (buttonAttributes != null)
            {
                foreach (var attr in buttonAttributes)
                    a.MergeAttribute(attr.Key, attr.Value.ToString());
            }
            //span.InnerHtml = htmlHelper.Display(expression).ToHtmlString();
            span.InnerHtml = img.ToString(TagRenderMode.Normal);
            a.InnerHtml +=  span.ToString(TagRenderMode.Normal);

            a.MergeAttributes<string, object>(htmlAttributes);
            a.MergeAttribute("href", targetUrl);
            a.MergeAttributes<string, object>(ajaxOptions.ToUnobtrusiveHtmlAttributes());
            return a.ToString(TagRenderMode.Normal);
        }
    }
}
