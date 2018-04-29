using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BootstrapHtmlHelper
{
    internal class HtmlFieldPrefixScope : IDisposable
    {
        internal readonly TemplateInfo TemplateInfo;
        internal readonly string PreviousHtmlFieldPrefix;

        public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
        {
            TemplateInfo = templateInfo;
            PreviousHtmlFieldPrefix = TemplateInfo.HtmlFieldPrefix;
            TemplateInfo.HtmlFieldPrefix = htmlFieldPrefix;
        }

        public void Dispose()
        {
            TemplateInfo.HtmlFieldPrefix = PreviousHtmlFieldPrefix;
        }
    }
}
