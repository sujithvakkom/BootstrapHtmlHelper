using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {

        public static IHtmlString AdminLTETextBoxAutoCompleteFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlTextBoxAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            IDictionary<string, object> htmlGlyphiconsAttributes,
            String glyphiconsName,
            AutoCompleteOptions autoCompleteOptions,
            bool showLabel = false,
            bool hasValidation = true,
            bool showGlyphicons = false)
        {
            if (autoCompleteOptions == null)
                return htmlHelper.AdminLTETextBoxFor(expression, 
                    htmlLabelAttributes, 
                    htmlTextBoxAttributes, 
                    htmlGroupAttributes, 
                    htmlGlyphiconsAttributes,
                    glyphiconsName,
                    showLabel:showLabel,
                    hasValidation:hasValidation,
                    showGlyphicons:showGlyphicons);

            return null;
                    }
    }
}
