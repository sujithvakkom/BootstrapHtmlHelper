using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static IHtmlString AdminLTEFromSubmitter(this HtmlHelper htmlHelper,
            string ButtonDisplayName,
            string LoadingElementId,
            IDictionary<string, object> buttonAttributes =null,
            string Image = "~/Images/progress.gif"//,
                             //IDictionary<string, object> htmlGlyphiconsAttributes=null,
                             //String glyphiconsName =null
            )
        {

            TagBuilder button = new TagBuilder("button");
            TagBuilder span = new TagBuilder("span");
            TagBuilder img = new TagBuilder("img");
            img.MergeAttribute("src", Image);
            img.MergeAttribute("width", "20");
            span.MergeAttribute("id", LoadingElementId);
            span.MergeAttribute("class", "center");
            span.MergeAttribute("style", "display:none; padding-left:10px");
            if (buttonAttributes != null)
            {
                foreach(var attr in buttonAttributes)
                button.MergeAttribute(attr.Key, attr.Value.ToString());
            }
            //span.InnerHtml = htmlHelper.Display(expression).ToHtmlString();
            span.InnerHtml = img.ToString(TagRenderMode.Normal);
            button.InnerHtml = (ButtonDisplayName + span.ToString(TagRenderMode.Normal));

            return MvcHtmlString.Create(button.ToString(TagRenderMode.Normal));
        }
    }
}