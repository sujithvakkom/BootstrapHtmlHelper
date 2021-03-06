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
using System.Web.Mvc.Ajax;
using HtmlAgilityPack;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString AjaxAdminLTEActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, AjaxOptions ajaxOptions, string carrot = null)
        {
            string controllerName = null;
            return AjaxAdminLTEActionLink(ajaxHelper,linkText, actionName, controllerName, ajaxOptions,carrot);
        }

        //
        // Summary:
        //     Returns an anchor element that contains the URL to the specified action method;
        //     when the action link is clicked, the action method is invoked asynchronously
        //     by using JavaScript.
        //
        // Parameters:
        //   ajaxHelper:
        //     The AJAX helper.
        //
        //   linkText:
        //     The inner text of the anchor element.
        //
        //   actionName:
        //     The name of the action method.
        //
        //   ajaxOptions:
        //     An object that provides options for the asynchronous request.
        //
        // Returns:
        //     An anchor element.
        //
        // Exceptions:
        //   T:System.ArgumentException:
        //     The linkText parameter is null or empty.
        public static MvcHtmlString AjaxAdminLTEActionLink(this AjaxHelper ajaxHelper, 
            string linkText, 
            string actionName, 
            string controllerName, 
            AjaxOptions ajaxOptions, 
            bool isNavSideBar, 
            string carrot = null)
        {
            if (isNavSideBar) return AjaxAdminLTEActionLink(
                ajaxHelper,
                linkText,
                actionName,
                controllerName,
                ajaxOptions,
                carrot);
            else
            {
                TagBuilder tagBuilderI = getCarrot(carrot);
                MvcHtmlString actionLink = ajaxHelper.ActionLink(linkText, actionName, controllerName, ajaxOptions);

                var doc = new HtmlDocument();
                doc.LoadHtml(actionLink.ToHtmlString());
                doc.DocumentNode.FirstChild.InnerHtml = (tagBuilderI.ToString(TagRenderMode.Normal) + doc.DocumentNode.FirstChild.InnerHtml);
                return MvcHtmlString.Create(doc.DocumentNode.InnerHtml);
            }

        }
        public static MvcHtmlString AjaxAdminLTEActionLink(this AjaxHelper ajaxHelper, string linkText, string actionName, string controllerName, AjaxOptions ajaxOptions, string carrot = null)
        {
            var selected = ajaxHelper.IsSelected(actions: actionName, controllers: null, cssClass: "active");
            string listId =  controllerName +"-" + actionName;
            TagBuilder tagBuilderLi = new TagBuilder("li");
            tagBuilderLi.Attributes.Add(new System.Collections.Generic.KeyValuePair<string,string>("id", listId));
                var funCal = ajaxOptions.OnSuccess == null ? "{0}" : ajaxOptions.OnSuccess;

            try
            {
                funCal = String.Format(funCal, "set_this_active('" + listId + "')");
            }
            catch (Exception)
            {

            }

            ajaxOptions.OnSuccess = funCal;

            TagBuilder tagBuilderI = getCarrot(carrot);

            //tagBuilderLi.InnerHtml += tagBuilderI;
            MvcHtmlString actionLink = ajaxHelper.ActionLink(linkText, actionName,controllerName ,ajaxOptions);

            tagBuilderLi.MergeAttribute("class", selected);

            var doc = new HtmlDocument();
            doc.LoadHtml(actionLink.ToHtmlString());
            doc.DocumentNode.FirstChild.InnerHtml = (tagBuilderI.ToString(TagRenderMode.Normal) + doc.DocumentNode.FirstChild.InnerHtml);

            tagBuilderLi.InnerHtml += doc.DocumentNode.InnerHtml;

            return MvcHtmlString.Create(tagBuilderLi.ToString(TagRenderMode.Normal));
        }
    }
}
