using BootstrapHtmlHelper.Helpers;
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

        public static string AdminLTESorter(this HtmlHelper htmlHelper, string columnName, string columnHeader, WebGrid grid)
        {
            return string.Format("{0} {1}", columnHeader, grid.SortColumn == columnName ?
                grid.SortDirection == SortDirection.Ascending ? "▲" :
                "▼" : string.Empty);
        }

        public static string AdminLTESorter(this HtmlHelper htmlHelper, string columnName, string columnHeader, MyWebGrid grid)
        {
            return string.Format("{0} {1}", columnHeader, grid.SortColumn == columnName ?
                grid.SortDirection == SortDirection.Ascending ? "▲" :
                "▼" : string.Empty);
        }
    }
}
