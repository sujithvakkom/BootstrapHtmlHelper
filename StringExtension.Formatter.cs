using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;
using System.ComponentModel;


namespace BootstrapHtmlHelper
{
    public static partial class StringInjectExtension
    {
        const string NUMARIC = "numaric";
        public static string AdminLTEFormatedString(this string expression, string htmlAttributes = NUMARIC,
            string Formate = null
            )
        {
            string formatedValue = "";
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
                            else if (htmlAttributes != null && htmlAttributes == NUMARIC)
                                formatedValue = String.Format("{0:n}", expression);
                            else formatedValue = expression.ToString();
                            break;
                        case TypeCode.String:
                        default:
                            formatedValue = string.IsNullOrEmpty(Formate) ? (string)expression : string.Format(Formate, expression);
                            break;
                    }
            }
            catch (Exception)
            {
                formatedValue = expression.ToString();
            }

            return formatedValue;
        }

    }
}
