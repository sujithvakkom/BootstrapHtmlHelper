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
        public static IHtmlString AdminLTEParagraph(this HtmlHelper htmlHelper,
            string expression//,
                             //IDictionary<string, object> htmlAttributes =null,
                             //IDictionary<string, object> htmlGlyphiconsAttributes=null,
                             //String glyphiconsName =null
            )
        {
            TagBuilder span = new TagBuilder("p");
            //span.InnerHtml = htmlHelper.Display(expression).ToHtmlString();
            span.InnerHtml = expression;
            return MvcHtmlString.Create(span.ToString(TagRenderMode.Normal));
        }
    }
}
