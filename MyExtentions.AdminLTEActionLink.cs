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

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {

        // LinkExtensions

        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "The purpose of these helpers is to use default parameters to simplify common usage.")]
        public static IHtmlString AdminLTEActionLink(this HtmlHelper htmlHelper, 
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
                    htmlAttributes,carrot));
        }
        #region helpers
        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, HtmlHelper htmlHelper, string carrot = null)
        {
            return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true /* includeImplicitMvcValues */,htmlHelper:htmlHelper,carrot:carrot);
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes)
        {
            return GenerateLink(requestContext, routeCollection, linkText, routeName, actionName, controllerName, null /* protocol */, null /* hostName */, null /* fragment */, routeValues, htmlAttributes);
        }

        public static string GenerateLink(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, string carrot = null)
        {
            return GenerateLinkInternal(requestContext, routeCollection, linkText, routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, htmlAttributes, true /* includeImplicitMvcValues */, carrot: carrot);
        }
        #endregion

        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, 
            string actionName, string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, 
            bool includeImplicitMvcValues, HtmlHelper htmlHelper,string carrot = null)
        {
            string url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues);

            var selected = htmlHelper.IsSelected(actions: actionName, controllers: controllerName,cssClass:"active");

            TagBuilder tagBuilderLi = new TagBuilder("li") { };

            TagBuilder tagBuilderI = getCarrot(carrot);

            TagBuilder tagBuilderA = new TagBuilder("a")
            {
                InnerHtml = tagBuilderI.ToString(renderMode:TagRenderMode.Normal)
                + @"<span>"
                + ((!String.IsNullOrEmpty(linkText)) ? HttpUtility.HtmlEncode(linkText) : String.Empty)
                + @"</span>"
            };
            tagBuilderA.MergeAttributes(htmlAttributes);
            tagBuilderA.MergeAttribute("href", url);
            tagBuilderLi.InnerHtml += tagBuilderA.ToString(TagRenderMode.Normal);
            tagBuilderLi.MergeAttribute("class", selected);
            return tagBuilderLi.ToString(TagRenderMode.Normal);
        }

        private static string GenerateLinkInternal(RequestContext requestContext, RouteCollection routeCollection, string linkText, string routeName, string actionName, 
            string controllerName, string protocol, string hostName, string fragment, RouteValueDictionary routeValues, IDictionary<string, object> htmlAttributes, 
            bool includeImplicitMvcValues,  string carrot = null)
        {
            string url = UrlHelper.GenerateUrl(routeName, actionName, controllerName, protocol, hostName, fragment, routeValues, routeCollection, requestContext, includeImplicitMvcValues);
            
            TagBuilder tagBuilderI = getCarrot(carrot);
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = tagBuilderI.ToString(renderMode: TagRenderMode.Normal)
                + @"<span>"
                + ((!String.IsNullOrEmpty(linkText)) ? HttpUtility.HtmlEncode(linkText) : String.Empty)
                + @"</span>"
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("href", url);
            return tagBuilder.ToString(TagRenderMode.Normal);
        }
        #region Extras
        private static IDictionary<string, object> AnchorAttributes(string accessKey, string charset, string coords, string cssClass, string dir, string hrefLang, string id, string lang, string name, string rel, string rev, string shape, string style, string target, string title)
        {
            var htmlAttributes = Attributes(cssClass, id, style);

            htmlAttributes.AddOptional("accesskey", accessKey);
            htmlAttributes.AddOptional("charset", charset);
            htmlAttributes.AddOptional("coords", coords);
            htmlAttributes.AddOptional("dir", dir);
            htmlAttributes.AddOptional("hreflang", hrefLang);
            htmlAttributes.AddOptional("lang", lang);
            htmlAttributes.AddOptional("name", name);
            htmlAttributes.AddOptional("rel", rel);
            htmlAttributes.AddOptional("rev", rev);
            htmlAttributes.AddOptional("shape", shape);
            htmlAttributes.AddOptional("target", target);
            htmlAttributes.AddOptional("title", title);

            return htmlAttributes;
        }

        private static IDictionary<string, object> Attributes(string cssClass, string id, string style)
        {
            var htmlAttributes = new RouteValueDictionary();

            htmlAttributes.AddOptional("class", cssClass);
            htmlAttributes.AddOptional("id", id);
            htmlAttributes.AddOptional("style", style);

            return htmlAttributes;
        }

        private static void AddOptional(this IDictionary<string, object> dictionary, string key, object value)
        {
            if (value != null)
            {
                dictionary[key] = value;
            }
        }
        #endregion
    }
}
