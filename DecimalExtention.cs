using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BootstrapHtmlHelper
{
    public static class DecimalExtention
    {
        public static bool IsNullOrValue(this decimal? value)
        {
            return (value ?? null) == null;
        }
    }
}
