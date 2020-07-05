using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {

        // LinkExtensions

        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "The purpose of these helpers is to use default parameters to simplify common usage.")]
        public static IHtmlString AdminLTEMenuActionLinkBlock(this HtmlHelper htmlHelper, 
            string linkText, 
            string actionName, 
            string controllerName = null, 
            string protocol = null, 
            string hostName = null, 
            string fragment = null, 
            object routeValues = null, 
            string accessKey = null, 
            string charset = null, 
            string coords = null, 
            string cssClass = null, 
            string dir = null, 
            string hrefLang = null, 
            string id = null, 
            string lang = null, 
            string name = null, 
            string rel = null, 
            string rev = null, 
            string shape = null, 
            string style = null, 
            string target = null, 
            string title = null,
            string carrot = null)
        {
            if (String.IsNullOrEmpty(linkText))
            {
                throw new ArgumentException("", "linkText");
            }
            IDictionary<string, object> htmlAttributes = AnchorAttributes(accessKey, charset, coords, cssClass, dir, hrefLang, id, lang, name, rel, rev, shape, style, target, title);
            return MvcHtmlString.Create(
                GenerateLink(
                    htmlHelper.ViewContext.RequestContext, 
                    htmlHelper.RouteCollection, 
                    linkText, 
                    null /* routeName */, 
                    actionName, 
                    controllerName, 
                    protocol, 
                    hostName,
                    fragment,
                    routeValues as RouteValueDictionary ?? new RouteValueDictionary(routeValues),
                    htmlAttributes,htmlHelper,carrot));
        }
    }
}
