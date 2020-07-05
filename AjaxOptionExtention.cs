using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc.Ajax;

namespace BootstrapHtmlHelper
{
    public static class AjaxOptionExtention
    {
        private static readonly Regex _idRegex = new Regex(@"[.:[\]]");
        public static string MyToJavascriptString(this AjaxOptions options)
        {
            // creates a string of the form { key1: value1, key2 : value2, ... }
            // This method is used for generating obtrusive JavaScript (using MicrosoftMvcAjax.js) which is no longer 
            // actively maintained. Consequently, we'll ignore the AllowCache option if it's set for this code path.
            StringBuilder optionsBuilder = new StringBuilder("{");
            optionsBuilder.AppendFormat(CultureInfo.InvariantCulture, " insertionMode: {0},", options.InsertionModeString());
            optionsBuilder.Append(PropertyStringIfSpecified("confirm", options.Confirm));
            optionsBuilder.Append(PropertyStringIfSpecified("httpMethod", options.HttpMethod));
            optionsBuilder.Append(PropertyStringIfSpecified("loadingElementId", options.LoadingElementId));
            optionsBuilder.Append(PropertyStringIfSpecified("updateTargetId", options.UpdateTargetId));
            optionsBuilder.Append(PropertyStringIfSpecified("url", options.Url));
            optionsBuilder.Append(EventStringIfSpecified("onBegin", options.OnBegin));
            optionsBuilder.Append(EventStringIfSpecified("onComplete", options.OnComplete));
            optionsBuilder.Append(EventStringIfSpecified("onFailure", options.OnFailure));
            optionsBuilder.Append(EventStringIfSpecified("onSuccess", options.OnSuccess));
            optionsBuilder.Length--;
            optionsBuilder.Append(" }");
            return optionsBuilder.ToString();
        }

        private static string PropertyStringIfSpecified(string propertyName, string propertyValue)
        {
            if (!String.IsNullOrEmpty(propertyValue))
            {
                string escapedPropertyValue = propertyValue.Replace("'", @"\'");
                return String.Format(CultureInfo.InvariantCulture, " {0}: '{1}',", propertyName, escapedPropertyValue);
            }
            return String.Empty;
        }

        private static string EventStringIfSpecified(string propertyName, string handler)
        {
            if (!String.IsNullOrEmpty(handler))
            {
                return String.Format(CultureInfo.InvariantCulture, " {0}: Function.createDelegate(this, {1}),", propertyName, handler.ToString());
            }
            return String.Empty;
        }

        internal static string InsertionModeString(this AjaxOptions options)
        {

                switch (options.InsertionMode)
                {
                    case InsertionMode.Replace:
                        return "replace";
                    case InsertionMode.InsertBefore:
                        return "insertBefore";
                    case InsertionMode.InsertAfter:
                        return "insertAfter";
                    default:
                        return ((int)options.InsertionMode).ToString(CultureInfo.InvariantCulture);
                }

        }

        public static IDictionary<string, object> MyToUnobtrusiveHtmlAttributes(this AjaxOptions options)
        {
            var result = new Dictionary<string, object>
            {
                { "data-ajax", "true" },
            };

            AddToDictionaryIfSpecified(result, "data-ajax-url", options.Url);
            AddToDictionaryIfSpecified(result, "data-ajax-method", options.HttpMethod);
            AddToDictionaryIfSpecified(result, "data-ajax-confirm", options.Confirm);

            AddToDictionaryIfSpecified(result, "data-ajax-begin", options.OnBegin);
            AddToDictionaryIfSpecified(result, "data-ajax-complete", options.OnComplete);
            AddToDictionaryIfSpecified(result, "data-ajax-failure", options.OnFailure);
            AddToDictionaryIfSpecified(result, "data-ajax-success", options.OnSuccess);

            //if (AllowCache)
            //{
            //    // On the client, the absence of the data-ajax-cache attribute is equivalent to setting it to false.
            //    // Consequently we'll only set it if the user wants to opt into caching. 
            //    AddToDictionaryIfSpecified(result, "data-ajax-cache", "true");
            //}

            if (!String.IsNullOrWhiteSpace(options.LoadingElementId))
            {
                result.Add("data-ajax-loading", EscapeIdSelector(options.LoadingElementId));

                if (options.LoadingElementDuration > 0)
                {
                    result.Add("data-ajax-loading-duration", options.LoadingElementDuration);
                }
            }

            if (!String.IsNullOrWhiteSpace(options.UpdateTargetId))
            {
                result.Add("data-ajax-update", EscapeIdSelector(options.UpdateTargetId));
                result.Add("data-ajax-mode", options.InsertionModeUnobtrusive());
            }

            return result;
        }

        // Helpers
        private static void AddToDictionaryIfSpecified(IDictionary<string, object> dictionary, string name, string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                dictionary.Add(name, value);
            }
        }

        private static string EscapeIdSelector(string selector)
        {
            // The string returned by this function is used as a value for jQuery's selector. The characters dot, colon and 
            // square brackets are valid id characters but need to be properly escaped since they have special meaning. For
            // e.g., for the id a.b, $('#a.b') would cause ".b" to treated as a class selector. The correct way to specify
            // this selector would be to escape the dot to get $('#a\.b').
            // See http://learn.jquery.com/using-jquery-core/faq/how-do-i-select-an-element-by-an-id-that-has-characters-used-in-css-notation/
            return '#' + _idRegex.Replace(selector, @"\$&");
        }

        public static string InsertionModeUnobtrusive(this AjaxOptions options)
        {

                switch (options.InsertionMode)
                {
                    case InsertionMode.Replace:
                        return "replace";
                    case InsertionMode.InsertBefore:
                        return "before";
                    case InsertionMode.InsertAfter:
                        return "after";
                    //case InsertionMode.ReplaceWith:
                    //    return "replace-with";
                    default:
                        return ((int)options.InsertionMode).ToString(CultureInfo.InvariantCulture);
                }

        }
    }
}
