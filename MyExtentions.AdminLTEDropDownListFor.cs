using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        #region
        /*
        
                        <div class="form-group">
                            <script>
                                function formatItem(state) {
                                    if (!state.id) {
                                        return state.description;
                                    }
                                    var $state = $(
                                      '<div><span>' + state.id + '</span></br>' + state.text + '</div>'
                                    );
                                    return $state;
                                }
                                $('#minimal').ready(function () {
                                    $('#minimal').select2({
                                        ajax: {
                                            url: '/JSON/ItemAutoCompleter',
                                            data: function (params) {
                                                var query = {
                                                    Search: params.term
                                                }

                                                // Query parameters will be ?search=[term]&type=public
                                                return query;
                                            },
                                            //dataType: 'json',
                                            processResults: function (data, params) {
                                                try {
                                                    params.page = params.page || 1;
                                                    var pageArr = [];
                                                    $.each(data.OutputList, function (index, item) {
                                                        pageArr.push({
                                                            id: item.item_code,
                                                            text: item.description
                                                        });
                                                    });
                                                    return {
                                                        results: pageArr,
                                                        pagination: {
                                                            more: (data.CountCurrPage + (data.CountPerPage * (params.page - 1))) < data.Count
                                                        }
                                                    };
                                                }
                                                catch (err) { alert(err.message) }
                                            }
                                        },
                                        templateResult: formatItem
                                        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                                    });
                                });
                            </script>
                            <label>Minimal</label>
                            <select id ="minimal"class="form-control select2" style="width:100%"></select>
                        </div>
              */
        #endregion

        const String AUTO_COMPLETE_DROP_SCRIPT =
        @"function formatItem(state) {
                                    if (!state.id) {
                                        return state.text;
                                    }
                                    var $state = $(
                                      {Formate}
                                    );
                                    return $state;
                                }
                                $('#minimal').ready(function () {
                                    $('#minimal').select2({
                                        ajax: {
                                            url: {AjaxURL},
                                            data: function (params) {
                                                var query = {
                                                    Search: params.term
                                                }

                                                // Query parameters will be ?search=[term]&type=public
                                                return query;
                                            },
                                            //dataType: 'json',
                                            processResults: function (data, params) {
                                                try {
                                                    params.page = params.page || 1;
                                                    var pageArr = [];
                                                    $.each(data.OutputList, function (index, item) {
                                                        pageArr.push({
                                                            id: {IDField},
                                                            text: {DescriptionField}
                                                        });
                                                    });
                                                    return {
                                                        results: pageArr,
                                                        pagination: {
                                                            more: (data.CountCurrPage + (data.CountPerPage * (params.page - 1))) < data.Count
                                                        }
                                                    };
                                                }
                                                catch (err) { alert(err.message) }
                                            }
                                        },
                                        templateResult: formatItem
                                        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
                                    });
                                });";

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "The purpose of these helpers is to use default parameters to simplify common usage.")]
        public static MvcHtmlString AdminLTEDropDownListFor<TModel>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, bool>> expression, 
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlDropDownAttributes,
            IDictionary<string, object> htmlGroupAttributes,
            IDictionary<string, object> htmlGlyphiconsAttributes,
            AutoCompleteOptions autoCompleteOptions,
            bool showLabel = false,
            bool hasValidation = true)
        {

            string name = ExpressionHelper.GetExpressionText(expression);
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException("Null name");
            }

            // If there are any errors for a named field, we add the css attribute.
            ModelState modelState;
            var formGroup = new TagBuilder("div");
            if (htmlGroupAttributes == null)
                formGroup.AddCssClass("form-group has-feedback");
            else
                foreach (var attribute in htmlGroupAttributes)
                {
                    formGroup.MergeAttribute(attribute.Key, attribute.Value.ToString());
                }
            formGroup.MergeAttribute("name", "form-group-" + fullName, true);

            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
            }

            if (htmlDropDownAttributes == null) htmlDropDownAttributes = new Dictionary<String, object>();
            s
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var z = memberExpression.Member;
                var y = z.GetAttribute<DisplayAttribute>();
                htmlDropDownAttributes.Add(new KeyValuePair<string, object>("placeholder", y.Name));
            }


            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            Dictionary<string, object> tembAttrib = new Dictionary<string, object>();


            //checkBoxLabel.InnerHtml = checkBoxSqure.ToString() + placeHolder;
            var dropDown = (autoCompleteOptions == null) ? htmlHelper.DropDownListFor(expression,
            selectList: autoCompleteOptions.GetSelectionList(),
            htmlAttributes: new Dictionary<string, string> { { "", "" } }) 
            :
            htmlHelper.DropDownListFor(expression,
            selectList: null,
            htmlAttributes: new Dictionary<string, string>
            {
                { "class", "form-control select2" }
            });

            TagBuilder script = new TagBuilder("script");

            JavaScriptResult x = new JavaScriptResult();
            x.Script = string.Format(AUTO_COMPLETE_DROP_SCRIPT, autoCompleteOptions);
            
            formGroup.InnerHtml = dropDown.ToHtmlString();
           

            return MvcHtmlString.Create(formGroup.ToString());

        }
    }
}
