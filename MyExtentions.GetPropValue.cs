using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
        
        public static string GetMemberExpressionName<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {

            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                return null;
            return memberExpression.Member.Name;
        }
        
        public static Type GetMemberExpressionType<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {

            var memberExpression = expression.Body as MemberExpression;

            if (memberExpression == null)
                return null;
            return memberExpression.Member.GetType();
        }

        private static object GetMemberExpressionValue<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            string propertyName = body.Member.Name;
            TModel model = helper.ViewData.Model;
            var value = typeof(TModel).GetProperty(propertyName).GetValue(model, null);
            return value;
        }
    }
}
