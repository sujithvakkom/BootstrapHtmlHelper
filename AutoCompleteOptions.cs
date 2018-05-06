using System.Web.Mvc.Ajax;

namespace BootstrapHtmlHelper
{
    public class AutoCompleteOptions
    {
        private bool _IsAutoComplete;
        public AutoCompleteOptions() {
            _IsAutoComplete = true;
        }
        public bool IsAutoComplete { get { return _IsAutoComplete; } set { _IsAutoComplete = value; } }
        AjaxOptions AjaxOptions { get; set; }
    }
}