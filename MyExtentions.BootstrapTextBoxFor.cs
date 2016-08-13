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
        /// Output:
        /// <div class="form-group">
        ///         <label>First Name</label>
        ///         <input class="form-control" data-val="true" data-val-required="The First Name field is required." id="Name" name="Name" placeholder="Description" value="" type="text">
        ///     </div>
        /// </summary>
        /// <typeparam name="TModel">Expression for Model</typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="showLabel"></param>
        /// <param name="htmlLabelAttributes"></param>
        /// <param name="htmlTextBoxAttributes"></param>
        /// <returns></returns>
        public static IHtmlString BootstrapTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, 
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlTextBoxAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            bool showLabel = true,
            bool hasValidation = true)
        {
            
            var formGroup = new TagBuilder("div");
            if (htmlGroupAttributes==null)
            formGroup.AddCssClass("form-group");
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
                var y= x.GetAttribute<DisplayAttribute>();
                htmlTextBoxAttributes.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            }
            //htmlTextBoxAttributes.Add(new KeyValuePair<string, object>("placeholder", expression.Name));
            
            var textbox = htmlHelper.PasswordFor(expression, htmlTextBoxAttributes);
            
            var validationSummary = htmlHelper.ValidationMessageFor(expression);

            //if (hasValidation) formGroup.AddCssClass("has-warning");

            formGroup.InnerHtml= (showLabel?htmlHelper.LabelFor(expression,htmlLabelAttributes).ToHtmlString():"")+
                textbox.ToHtmlString()+
                (hasValidation?validationSummary.ToHtmlString():"");
            /*formGroup.SetInnerText(
                (showLabel?htmlHelper.LabelFor(expression,htmlLabelAttributes).ToHtmlString():"")+
                textbox.ToHtmlString()
                );
            */
            return MvcHtmlString.Create(formGroup.ToString());
        }
        
    }
}