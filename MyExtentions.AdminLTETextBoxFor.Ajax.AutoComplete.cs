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
                    showLabel: showLabel,
                    hasValidation: hasValidation,
                    showGlyphicons: showGlyphicons);


            string name = ExpressionHelper.GetExpressionText(expression);
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Null name");
            }

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            var formGroup = new TagBuilder("div");
            if (htmlGroupAttributes == null)
                formGroup.AddCssClass("form-group has-feedback");
            else
                foreach (var attribute in htmlGroupAttributes)
                {
                    formGroup.MergeAttribute(attribute.Key, attribute.Value.ToString());
                }
            formGroup.MergeAttribute("name", "form-group-" + fullName, true);


            //If Model has error UI is updated
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
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

            modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = (((modelErrors == null) || (modelErrors.Count == 0)) ? null : modelErrors.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0]);

            var validationSummary = htmlHelper.ValidationMessageFor(expression, null,
                new { @class = "help-block" });


            //     <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
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
