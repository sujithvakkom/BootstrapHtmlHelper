using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BootstrapHtmlHelper
{
    public static class Extention
    {
        public static string GetErrors(this ModelStateDictionary values)
        {
            string ModelErrors = "";
            foreach (ModelState modelState in values.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    ModelErrors = ModelErrors == "" ? error.ErrorMessage :
                        ModelErrors + Environment.NewLine + error.ErrorMessage;
                }
            } 
            return ModelErrors;
        }
    }
}