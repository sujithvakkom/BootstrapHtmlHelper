using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapHtmlHelper.DecimalExtention
{
    public static class Extention
    {
        public static bool IsNullOrValue(this decimal? value)
        {
            return (value ?? null) == null;
        }
        public static bool IsNullOrValue(this decimal? value, decimal valueToCheck)
        {
            return (value ?? valueToCheck) == valueToCheck;
        }
    }
}
