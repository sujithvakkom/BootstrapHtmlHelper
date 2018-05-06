using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace BootstrapHtmlHelper
{
    public class AutoCompleteOptions
    {
        private bool _IsAutoComplete;
        public AutoCompleteOptions()
        {
            _IsAutoComplete = true;
        }
        public bool IsAutoComplete { get { return _IsAutoComplete; } set { _IsAutoComplete = value; } }
        public AjaxOptions AjaxOptions { get; set; }
        public IDictionary<object, object> SelectItems { get; set; }

        private string _Formate;
        public string Formate
        {
            get
            {
                if (_Formate == null) { return "<span>state.text</span>"; }
                else return _Formate;
            }
            set { _Formate = value; }
        }
        public string AjaxURL { get { return AjaxOptions.Url; } }
        private string _IDField;
        private string _DescriptionField;
        public string IDField { get { return _IDField == null ? "id" : _IDField; } set { _IDField = value; } }
        public string DescriptionField { get { return _DescriptionField == null ? "text" : _DescriptionField; } set { _DescriptionFieldS = value; } }

        public IEnumerable<SelectListItem> GetSelectionList()
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            if (SelectItems != null)
            {
                foreach (var x in SelectItems)
                    selectList.Add(new SelectListItem() { Selected = false, Value = x.Key.ToString(), Text = x.Value.ToString() });
            }
            return selectList;
        }
    }
}