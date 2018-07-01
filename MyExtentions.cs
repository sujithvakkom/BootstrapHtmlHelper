using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static TagBuilder getTag(string tag,
            IDictionary<string, object> htmlGroupAttributes)
        {

            TagBuilder formGroup = (tag == null) ? new TagBuilder("div") : new TagBuilder(tag);
            if ((tag == null) && (htmlGroupAttributes == null))
                formGroup.AddCssClass("form-group has-feedback");
            else
                try
                {
                    foreach (var attribute in htmlGroupAttributes)
                    {
                        formGroup.Attributes.Add(attribute.Key, attribute.Value.ToString());
                    }
                }
                catch (Exception) { }
            return formGroup;
        }

        public static TagBuilder getCarrot(string carrot = null)
        {
            TagBuilder tagBuilderI = new TagBuilder("i");
            if (carrot != null)
                foreach (var word in carrot.Split(new char[] { ' ' }))
                {
                    tagBuilderI.AddCssClass(word);
                }
            return tagBuilderI;
        }
    }
}
