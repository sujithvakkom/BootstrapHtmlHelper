﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "The purpose of these helpers is to use default parameters to simplify common usage.")]
        public static MvcHtmlString AdminLTECheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, bool>> expression, 
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlCheckBoxAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            IDictionary<string, object> htmlGlyphiconsAttributes,
            bool showLabel = false,
            bool hasValidation = true)
        {

            string name = ExpressionHelper.GetExpressionText(expression);
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Null name");
            }

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            Dictionary<string, object> tembAttrib = new Dictionary<string, object>();
            tembAttrib.Add("class", "checkbox icheck");
            var formGroup = getTag("div", tembAttrib);
            /*
            formGroup.MergeAttribute("name", "form-group-" + fullName, true);
            //If Model has error UI is updated
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
            }
             * */
            tembAttrib = htmlLabelAttributes!=null? (Dictionary<string, object>) htmlLabelAttributes: new Dictionary<string, object>();
            if(!tembAttrib.ContainsKey("class"))
                tembAttrib.Add("class","");
            if (!showLabel)
            {
                tembAttrib["class"] += (" " + "text-transparent");
            }
            var checkBoxLabel = getTag("label", tembAttrib);

            tembAttrib = new Dictionary<string, object>();
            tembAttrib.Add("class", "icheckbox_square-blue");
            tembAttrib.Add("aria-disabled", "false");
            tembAttrib.Add("aria-checked", "false");
            tembAttrib.Add("style","position: relative;");
            var checkBoxSqure = getTag("div", tembAttrib);

            tembAttrib = new Dictionary<string, object>();

            //Some attributes not working in check box.rafeeq changed exist attiributes.Old one commented
            //tembAttrib.Add("style", "position: absolute; top: -20%; left: -20%; display: block; width: 140%; height: 140%; margin: 0px; padding: 0px; background: rgb(255, 255, 255) none repeat scroll 0% 0%; border: 0px none; opacity: 0;");
            tembAttrib.Add("style", "position: absolute; top: -20%; left: 40%; display: block; margin-left: 10px;  background: rgb(255, 255, 255) none repeat scroll 0% 0%; border: 0px none; ");
            tembAttrib.Add("type", "checkbox");
            //var inp = getTag("input", tembAttrib);
            foreach (var attr in htmlCheckBoxAttributes) {
                if (tembAttrib.ContainsKey(attr.Key))
                    tembAttrib[attr.Key] += (" "+attr.Value);
                tembAttrib.Add(attr.Key, attr.Value);
            }


            var checkBox  = htmlHelper.CheckBoxFor(expression,tembAttrib);

            tembAttrib = new Dictionary<string, object>();
            tembAttrib.Add("class", "iCheck-helper");
            tembAttrib.Add("style", "position: absolute; top: -20%; left: -20%; display: block; margin: 0px; padding: 0px; background: rgb(255, 255, 255) none repeat scroll 0% 0%; border: 0px none; opacity: 0;");
            var insCheckHelper = getTag("ins", tembAttrib);

            checkBoxSqure.InnerHtml = checkBox.ToString() + insCheckHelper.ToString();

            string placeHolder = "";// getTag("span", new Dictionary<string, object>());
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var x = memberExpression.Member;
                var y = x.GetAttribute<DisplayAttribute>();
                placeHolder = showLabel ? y.Name:"i";
            }

            checkBoxLabel.InnerHtml =  checkBoxSqure.ToString()+placeHolder.ToString() ;


            formGroup.InnerHtml =  checkBoxLabel.ToString();

            return MvcHtmlString.Create(formGroup.ToString());

        }
    }
}
