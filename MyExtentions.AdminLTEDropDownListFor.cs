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

        #region script_desing
        const String AUTO_COMPLETE_DROP_SCRIPT =
        @"function formatItem{ModelIDFunction}(state) {
                                    if (!state.id) {
                                        return state.text;
                                    }
                                    var $state = $(
                                      {Formate}
                                    );
                                    return $state;
                                }
                                $('#form-group-{ModelID} > .select2').ready(function () {
                                    $('#form-group-{ModelID} > .select2').select2({
                                        data:{FromatedSelectedData},
                                        placeholder:'{PlaceHolder}',
                                        ajax: {
                                            url: '{AjaxURL}',
                                            data: function (params) {
                                                var query = {
                                                    Search: params.term,
                                                    Page: params.page || 1
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
                                                            id: item.{IDField},
                                                            text: item.{DescriptionField}
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
                                        templateResult: formatItem{ModelIDFunction}
                                        // Additional AJAX parameters go here; see the end of this chapter for the full code of this example

                                    });
                                });";
        #endregion

        /// <summary>
        ///
        /// @Html.AdminLTEDropDownListFor(
        ///	m=>m.ItemCode,
        ///	htmlLabelAttributes:null,
        ///	htmlDropDownAttributes:new Dictionary<string,object>(){
        ///			{"class","form-controlselect2"}
        ///		},
        ///	htmlGroupAttributes:null,
        ///	htmlGlyphiconsAttributes:null,
        ///	autoCompleteOptions:new AutoCompleteOptions()
        ///		{
        ///			AjaxOptions=newAjaxOptions()
        ///			{
        ///				HttpMethod = "GET",
        ///				Url = Url.Action(
        ///					actionName:"ItemAutoCompleter",
        ///					controllerName:"JSON")
        ///			},
        ///			DescriptionField = "description",
        ///			IDField = "item_code",
        ///			Formate = "'<div><span>'+state.id+'</span></br>'+state.text+'</div>'",
        ///			SelectedItem= ViewData["SELECTED_FILTED_ITEM"], //Current Select Item Model
        ///			IsAutoComplete= true,
        ///			SelectItems = null //Select List for Options
        ///		}
        ///)
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="htmlHelper"></param>
        /// <param name="expression"></param>
        /// <param name="htmlLabelAttributes"></param>
        /// <param name="htmlDropDownAttributes"></param>
        /// <param name="htmlGroupAttributes"></param>
        /// <param name="htmlGlyphiconsAttributes"></param>
        /// <param name="autoCompleteOptions">
        ///	autoCompleteOptions:new AutoCompleteOptions()
        ///		{
        ///			AjaxOptions=newAjaxOptions()
        ///			{
        ///				HttpMethod = "GET",
        ///				Url = Url.Action(
        ///					actionName:"ItemAutoCompleter",
        ///					controllerName:"JSON")
        ///			},
        ///			DescriptionField = "description",
        ///			IDField = "item_code",
        ///			Formate = "'<div><span>'+state.id+'</span></br>'+state.text+'</div>'",
        ///			SelectedItem= ViewData["SELECTED_FILTED_ITEM"], //Current Select Item Model
        ///			IsAutoComplete= true,
        ///			SelectItems = null //Select List for Options
        ///		}
        /// </param>
        /// <param name="showLabel"></param>
        /// <param name="hasValidation"></param>
        /// <returns>MvcHtmlString</returns>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures", Justification = "This is an appropriate nesting of generic types")]
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "The purpose of these helpers is to use default parameters to simplify common usage.")]
        public static MvcHtmlString AdminLTEDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
            Expression<Func<TModel, TProperty>> expression, 
            IDictionary<string, object> htmlLabelAttributes,
            IDictionary<string, object> htmlDropDownAttributes,
            IDictionary<string, object> htmlGroupAttributes,
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
            formGroup.MergeAttribute("id", "form-group-" + fullName.Replace('[', '_').Replace(']', '_').Replace('.', '_'), true);

            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    formGroup.AddCssClass("has-error");
                }
            }

            if (htmlDropDownAttributes == null) htmlDropDownAttributes = new Dictionary<String, object>();
            if(htmlDropDownAttributes["class"]==null)
                htmlDropDownAttributes.Add("class", "form-control select2");
            htmlDropDownAttributes.Add("style", "width:100%");

            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            Dictionary<string, object> tembAttrib = new Dictionary<string, object>();


            //checkBoxLabel.InnerHtml = checkBoxSqure.ToString() + placeHolder;
            MvcHtmlString dropDown = null;
            IEnumerable<SelectListItem> selectDummy = new List<SelectListItem>() { };

            if (autoCompleteOptions == null)
                dropDown = (htmlHelper.DropDownListFor(expression,
            selectList: autoCompleteOptions.GetSelectionList(),
            htmlAttributes: new Dictionary<string, string> { { "", "" } }));
            else
                dropDown =
                    (htmlHelper.DropDownListFor(expression,
                    selectList: selectDummy,
                    htmlAttributes: htmlDropDownAttributes));

            var validationSummary = htmlHelper.ValidationMessageFor(expression, null,
                new { @class = "help-block" });

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression != null)
            {
                var z = memberExpression.Member;
                var y = z.GetAttribute<DisplayAttribute>();
                autoCompleteOptions.PlaceHolder = y.Name;
            }

            TagBuilder script = new TagBuilder("script");


            autoCompleteOptions.ModelID = fullName.Replace('[', '_').Replace(']', '_').Replace('.', '_');
            autoCompleteOptions.ModelIDFunction = fullName.Replace('[', '_').Replace(']', '_').Replace('.', '_');
            script.InnerHtml = AUTO_COMPLETE_DROP_SCRIPT.Inject(autoCompleteOptions);

            formGroup.InnerHtml = script.ToString(TagRenderMode.Normal)
                + (showLabel ? htmlHelper.LabelFor(expression, htmlLabelAttributes).ToHtmlString() : "")
                + dropDown.ToHtmlString()
                + (hasValidation ? validationSummary.ToHtmlString() : "");
           

            return MvcHtmlString.Create(formGroup.ToString());

        }
    }
}
