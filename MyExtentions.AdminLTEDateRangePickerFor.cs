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
        /// <summary>
        /// <div class="form-group has-feedback">
        ///     <input type="email" class="form-control" placeholder="Email">
        ///     <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
        /// </div>
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expressionStartDate"></param>
        /// <param name="htmlLabelAttributes"></param>
        /// <param name="htmlTextBoxAttributes"></param>
        /// <param name="htmlGroupAttributes"></param>
        /// <param name="showLabel"></param>
        /// <param name="hasValidation"></param>
        /// <returns></returns>
        public static IHtmlString AdminLTEDateRangePickerFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expressionStartDate,
            Expression<Func<TModel, TProperty>> expressionEndDate,
            string label,
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlTextBoxAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            IDictionary<string, object> htmlGlyphiconsAttributes,
            String glyphiconsName,
            bool showLabel = false,
            bool hasValidation = true,
            bool showGlyphicons = false)
        {
            string nameStart = ExpressionHelper.GetExpressionText(expressionStartDate);
            string fullNameStart = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(nameStart);
            if (String.IsNullOrEmpty(fullNameStart))
            {
                throw new ArgumentException("Null name");
            }
            string nameEnd = ExpressionHelper.GetExpressionText(expressionEndDate);
            string fullNameEnd = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(nameEnd);
            if (String.IsNullOrEmpty(fullNameStart))
            {
                throw new ArgumentException("Null name");
            }

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelStateStart;

            string modelNameStart = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(nameStart);

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelStateEnd;

            string modelNameEnd = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(nameEnd);

            var formGroup = new TagBuilder("div");
            if (htmlGroupAttributes == null)
                formGroup.AddCssClass("form-group has-feedback");
            else
                foreach (var attribute in htmlGroupAttributes)
                {
                    formGroup.MergeAttribute(attribute.Key, attribute.Value.ToString());
                }
            formGroup.MergeAttribute("name", "form-group-" + fullNameStart+fullNameEnd, true);
            formGroup.MergeAttribute("id", "form-group-" + fullNameStart + fullNameEnd, true);


            //If Model has error UI is updated
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullNameStart, out modelStateStart))
            {
                if (modelStateStart.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
            }


            //If Model has error UI is updated
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullNameEnd, out modelStateEnd))
            {
                if (modelStateStart.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
            }

            if (htmlTextBoxAttributes == null) htmlTextBoxAttributes = new Dictionary<String, object>();
            IDictionary<string, object> htmlTextBoxAttributesEnd = new Dictionary<String, object>(htmlTextBoxAttributes);

            var memberExpressionStart = expressionStartDate.Body as MemberExpression;
            if (memberExpressionStart != null)
            {
                var x = memberExpressionStart.Member;
                var y = x.GetAttribute<DisplayAttribute>();
                htmlTextBoxAttributes.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            }

            //var memberExpressionEnd = expressionEndDate.Body as MemberExpression;
            //if (memberExpressionStart != null)
            //{
            //    var x = memberExpressionStart.Member;
            //    var y = x.GetAttribute<DisplayAttribute>();
            //    htmlTextBoxAttributesEnd.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            //}
            ////Updated by rafeeq 
            var memberExpressionEnd = expressionEndDate.Body as MemberExpression;
            if (memberExpressionEnd != null)
            {
                var x = memberExpressionEnd.Member;
                var y = x.GetAttribute<DisplayAttribute>();
                htmlTextBoxAttributesEnd.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            }

            var textboxStart = htmlHelper.TextBoxFor(expressionStartDate, htmlTextBoxAttributes);

            var textboxEnd = htmlHelper.TextBoxFor(expressionEndDate, htmlTextBoxAttributesEnd);

            modelStateStart = htmlHelper.ViewData.ModelState[modelNameStart];
            ModelErrorCollection modelErrorsStart = (modelStateStart == null) ? null : modelStateStart.Errors;
            ModelError modelErrorStart = (((modelErrorsStart == null) || (modelErrorsStart.Count == 0)) ? null : modelErrorsStart.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrorsStart[0]);

            modelStateEnd = htmlHelper.ViewData.ModelState[modelNameStart];
            ModelErrorCollection modelErrorsEnD = (modelStateEnd == null) ? null : modelStateEnd.Errors;
            ModelError modelErrorEnd = (((modelErrorsEnD == null) || (modelErrorsEnD.Count == 0)) ? null : modelErrorsEnD.FirstOrDefault(m => !String.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrorsEnD[0]);

            var validationSummaryStartDate = htmlHelper.ValidationMessageFor(expressionStartDate, null,
                new { @class = "help-block" });
            var validationSummaryEndDate = htmlHelper.ValidationMessageFor(expressionEndDate, null,
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


            TagBuilder script = new TagBuilder("script");
            script.InnerHtml =
                @"$('#"
                + "form-group-" + fullNameStart + fullNameEnd +
                @"').each(function() {
                                $(this).datepicker({format: 'dd M yyyy'})
                                     });";
            //<span class="input-group-addon">to</span>
            TagBuilder inputGroupAddon = new TagBuilder("span");
            inputGroupAddon.AddCssClass("input-group-addon");
            inputGroupAddon.InnerHtml = "to";

            formGroup.InnerHtml = 
                textboxStart.ToHtmlString() +
                //(showGlyphicons ? spanGlyphicons.ToString() : "")+
                inputGroupAddon.ToString() +
                textboxEnd.ToHtmlString() +
                (showGlyphicons ? spanGlyphicons.ToString() : "");
            /*formGroup.SetInnerText(
                (showLabel?htmlHelper.LabelFor(expression,htmlLabelAttributes).ToHtmlString():"")+
                textbox.ToHtmlString()
                );
            */
            formGroup.AddCssClass("input-group");
            formGroup.AddCssClass("input-daterange");
            TagBuilder div = new TagBuilder("div");
            div.InnerHtml = script.ToString(TagRenderMode.Normal) +
                (showLabel ? htmlHelper.Label(label, htmlLabelAttributes).ToHtmlString() : "") +
                formGroup.ToString(TagRenderMode.Normal) +
                (hasValidation ? validationSummaryStartDate.ToHtmlString() : "")+
                (hasValidation ? validationSummaryEndDate.ToHtmlString() : "");

            return MvcHtmlString.Create(div.ToString(TagRenderMode.Normal));
        }
    }
}
