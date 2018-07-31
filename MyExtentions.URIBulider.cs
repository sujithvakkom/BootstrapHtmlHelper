using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static string ToQueryString(this UriBuilder builder,NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            var query = "?" + string.Join("&", array);


            if (builder.Query != null && builder.Query.Length > 1)
                builder.Query = builder.Query.Substring(1) + "&" + query;
            else
                builder.Query = query;
            return builder.ToString();
        }
    }
}
