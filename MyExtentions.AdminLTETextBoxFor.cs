using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// <div class="form-group has-feedback">
        ///     <input type="email" class="form-control" placeholder="Email">
        ///     <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        /// </div>
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlLabelAttributes"></param>
        /// <param name="htmlTextBoxAttributes"></param>
        /// <param name="htmlGroupAttributes"></param>
        /// <param name="showLabel"></param>
        /// <param name="hasValidation"></param>
        /// <returns></returns>
        public static IHtmlString AdminLTETextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlTextBoxAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            IDictionary<string, object> htmlGlyphiconsAttributes,
            String glyphiconsName,
            bool showLabel = false,
            bool hasValidation = true,
            bool showGlyphicons = false)
        {

            var formGroup = new TagBuilder("div");
            if (htmlGroupAttributes == null)
                formGroup.AddCssClass("form-group has-feedback");
            else
                foreach (var attribute in htmlGroupAttributes)
                {
                    formGroup.Attributes.Add(attribute.Key, attribute.Value.ToString());
                }

            if (htmlTextBoxAttributes == null) htmlTextBoxAttributes = new Dictionary<String, object>();

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var x = memberExpression.Member;
                var y = x.GetAttribute<DisplayAttribute>();
                htmlTextBoxAttributes.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            }
            //htmlTextBoxAttributes.Add(new KeyValuePair<string, object>("placeholder", expression.Name));

            var textbox = htmlHelper.TextBoxFor(expression, htmlTextBoxAttributes);

            var validationSummary = htmlHelper.ValidationMessageFor(expression);


            ///     <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
            var spanGlyphicons = new TagBuilder("span");
            spanGlyphicons.AddCssClass("fa");
            spanGlyphicons.AddCssClass("form-control-feedback");
            spanGlyphicons.AddCssClass(glyphiconsName);

            if (!(htmlGlyphiconsAttributes == null))
                foreach (var attribute in htmlGlyphiconsAttributes)
                {
                    formGroup.Attributes.Add(attribute.Key, attribute.Value.ToString());
                }

            //if (hasValidation) formGroup.AddCssClass("has-warning");

            formGroup.InnerHtml = (showLabel ? htmlHelper.LabelFor(expression, htmlLabelAttributes).ToHtmlString() : "") +
                textbox.ToHtmlString() +
                (hasValidation ? validationSummary.ToHtmlString() : "") +
                (showGlyphicons ? spanGlyphicons.ToString() : "");
            /*formGroup.SetInnerText(
                (showLabel?htmlHelper.LabelFor(expression,htmlLabelAttributes).ToHtmlString():"")+
                textbox.ToHtmlString()
                );
            */
            return MvcHtmlString.Create(formGroup.ToString());
        }
    }
}
