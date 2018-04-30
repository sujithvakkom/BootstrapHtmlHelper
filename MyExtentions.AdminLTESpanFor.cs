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
        /// <summary>
        /// <div class="form-group has-feedback">
        ///     <input type="email" class="form-control" placeholder="Email">
        ///     <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        /// </div>
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <returns></returns>
        public static IHtmlString AdminLTESpanFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression//,
                                                          //IDictionary<string, object> htmlAttributes =null,
                                                          //IDictionary<string, object> htmlGlyphiconsAttributes=null,
                                                          //String glyphiconsName =null
            )
        {
            TagBuilder span = new TagBuilder("span");
            span.InnerHtml = htmlHelper.DisplayFor(expression).ToHtmlString();
            return MvcHtmlString.Create(span.ToString(TagRenderMode.Normal));
        }
    }
}
