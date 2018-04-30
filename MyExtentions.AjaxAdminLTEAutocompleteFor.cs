using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static MvcHtmlString AjaxAdminLTEAutocompleteFor<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression, string actionName, string controllerName)
        {
            string autocompleteUrl = UrlHelper.GenerateUrl(null, actionName, controllerName,
                                                           null,
                                                           html.RouteCollection,
                                                           html.ViewContext.RequestContext,
                                                           includeImplicitMvcValues: true);
            return html.TextBoxFor(expression, new { data_autocomplete_url = autocompleteUrl });
        }
    }
}
