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
        public static string NUMARIC = "numaric";
        public static MvcHtmlString AdminLTEParagraph<TModel>(this HtmlHelper htmlHelper,
            TModel expression,
            IDictionary<string, object> htmlAttributes = null,
            string Formate = null
            )
        {
            string temp = htmlAttributes == null ? "" : htmlAttributes["class"] == null ? "" : htmlAttributes["class"].ToString();
            string formatedValue = "";
            TagBuilder span = new TagBuilder("p");
            if (htmlAttributes != null)
                foreach (var attribute in htmlAttributes)
                {
                    span.MergeAttribute(attribute.Key, attribute.Value.ToString());
                }
            try
            {
                if (expression != null)
                    //span.InnerHtml = htmlHelper.Display(expression).ToHtmlString();
                    switch (Type.GetTypeCode(expression.GetType()))
                    {
                        case TypeCode.Decimal:
                        case TypeCode.Int16:
                        case TypeCode.Int32:
                        case TypeCode.Int64:
                        case TypeCode.UInt16:
                        case TypeCode.UInt32:
                        case TypeCode.UInt64:
                        case TypeCode.Double:
                        case TypeCode.Single:
                            if (!string.IsNullOrEmpty(Formate))
                                formatedValue = string.Format(Formate, expression);
                            else if (htmlAttributes != null && temp.Contains(NUMARIC))
                                formatedValue = String.Format("{0:n}", expression);
                            else formatedValue = expression.ToString();
                            break;
                        case TypeCode.String:
                        default:
                            formatedValue = string.IsNullOrEmpty(Formate) ? expression.ToString() : string.Format(Formate, expression);
                            break;
                    }
            }
            catch (Exception)
            {
                formatedValue = expression.ToString();
            }

            span.InnerHtml = formatedValue;
            return MvcHtmlString.Create(span.ToString(TagRenderMode.Normal));
        }
        public static MvcHtmlString AdminLTEParagraphFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression,
            IDictionary<string, object> htmlAttributes = null,
            string Formate = null
            )
        {
            var name = htmlHelper.GetMemberExpressionName(expression);
            
            var type= htmlHelper.GetMemberExpressionType(expression);

            var value = htmlHelper.GetMemberExpressionValue(expression);
            //var value = htmlHelper.ValueFor(expression);
            if (!htmlAttributes.ContainsKey("id")) htmlAttributes.Add("id", name);
            return htmlHelper.AdminLTEParagraph(
                value, 
                htmlAttributes, 
                Formate
                );
        }
    }
}
