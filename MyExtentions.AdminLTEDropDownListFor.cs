using System;
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
        public static MvcHtmlString AdminLTEDropDownListFor<TModel>(this HtmlHelper<TModel> htmlHelper, 
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
            //ModelState modelState;

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            Dictionary<string, object> tembAttrib = new Dictionary<string, object>();
            tembAttrib.Add("class", "");
            var formGroup = getTag("div", tembAttrib);

            string placeHolder = "";
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var x = memberExpression.Member;
                var y = x.GetAttribute<DisplayAttribute>();
                placeHolder = y.Name;
            }

            //checkBoxLabel.InnerHtml = checkBoxSqure.ToString() + placeHolder;

            formGroup.InnerHtml = 
            htmlHelper.DropDownListFor(expression,
            selectList: null,
            htmlAttributes: new Dictionary<string, string> { { "", "" } }).ToHtmlString();

            return MvcHtmlString.Create(formGroup.ToString());

        }
    }
}
