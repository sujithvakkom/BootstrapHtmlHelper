using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.WebPages;

namespace BootstrapHtmlHelper
{
    public static partial class MyExtentions
    {
        public static HelperResult Pager(this AjaxHelper helper, WebGrid webGrid, string TargetDiv,
            WebGridPagerModes mode = WebGridPagerModes.NextPrevious | WebGridPagerModes.Numeric,
            string firstText = null,
            string previousText = null,
            string nextText = null,
            string lastText = null,
            int numericLinksCount = 5, string ActionName = "Index",
            bool explicitlyCalled = true)
        {
            int currentPage = webGrid.PageIndex;
            int totalPages = webGrid.PageCount;
            int PageSize = webGrid.RowsPerPage;

            int lastPage = totalPages - 1;

            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");

            var li = new List<TagBuilder>();

            if (webGrid.TotalRowCount <= webGrid.PageCount)
            {
                return new HelperResult(writer =>
                {
                    writer.Write(string.Empty);
                });
            }

            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (String.IsNullOrEmpty(firstText))
                {
                    firstText = "First";
                }
                var url = webGrid.GetPageUrl(0);
                var part = new TagBuilder("li")
                {
                    InnerHtml = helper.GridActionLink(webGrid, 0, ActionName, firstText).ToHtmlString()
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }
                part.AddCssClass("page-item");

                li.Add(part);

            }
            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (String.IsNullOrEmpty(previousText))
                {
                    previousText = "Prev";
                }

                int page = currentPage == 0 ? 0 : currentPage - 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = helper.GridActionLink(webGrid, page, ActionName, previousText).ToHtmlString()
                };

                if (currentPage == 0)
                {
                    part.MergeAttribute("class", "disabled");
                }

                part.AddCssClass("page-item");
                li.Add(part);

            }
            if (ModeEnabled(mode, WebGridPagerModes.Numeric) && (totalPages > 1))
            {
                int last = currentPage + (numericLinksCount / 2);
                int first = last - numericLinksCount + 1;
                if (last > lastPage)
                {
                    first -= last - lastPage;
                    last = lastPage;
                }
                if (first < 0)
                {
                    last = Math.Min(last + (0 - first), lastPage);
                    first = 0;
                }
                for (int i = first; i <= last; i++)
                {

                    var pageText = (i + 1).ToString(CultureInfo.InvariantCulture);
                    var part = new TagBuilder("li")
                    {
                        InnerHtml = helper.GridActionLink(webGrid, i +1, ActionName, pageText).ToHtmlString()
                    };

                    if (i == currentPage)
                    {
                        part.MergeAttribute("class", "active");
                    }

                    part.AddCssClass("page-item");
                    li.Add(part);

                }
            }
            if (ModeEnabled(mode, WebGridPagerModes.NextPrevious))
            {
                if (String.IsNullOrEmpty(nextText))
                {
                    nextText = "Next";
                }

                int page = currentPage == lastPage ? lastPage : currentPage + 1;

                var part = new TagBuilder("li")
                {
                    InnerHtml = helper.GridActionLink(webGrid, page, ActionName, nextText).ToHtmlString()
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                part.AddCssClass("page-item");
                li.Add(part);

            }
            if (ModeEnabled(mode, WebGridPagerModes.FirstLast))
            {
                if (String.IsNullOrEmpty(lastText))
                {
                    lastText = "Last";
                }

                var part = new TagBuilder("li")
                {
                    InnerHtml = helper.GridActionLink(webGrid,lastPage, ActionName, lastText).ToHtmlString()
                };

                if (currentPage == lastPage)
                {
                    part.MergeAttribute("class", "disabled");
                }

                part.AddCssClass("page-item");
                li.Add(part);

            }
            ul.InnerHtml = string.Join("", li);

            var html = "";
            if (explicitlyCalled && webGrid.IsAjaxEnabled)
            {
                var span = new TagBuilder("span");
                //span.MergeAttribute("data-swhgajax", "true");
                //span.MergeAttribute("data-swhgcontainer", webGrid.AjaxUpdateContainerId);
                //span.MergeAttribute("data-swhgcallback", webGrid.AjaxUpdateCallback);

                span.InnerHtml = ul.ToString();
                html = span.ToString();

            }
            else
            {
                html = ul.ToString();
            }


            return new HelperResult(writer =>
            {
                writer.Write(html);
            });

        }

        private static MvcHtmlString GridActionLink(this AjaxHelper helper, WebGrid webGrid, int page, string actionName, string text)
        {
            string url = "";
            if (webGrid.PageCount < page)
                url = webGrid.GetPageUrl(page);
            //webGrid.sor
            return helper.ActionLink(text, actionName, new { @Page = page }, new AjaxOptions() {
                UpdateTargetId = webGrid.AjaxUpdateContainerId
            }, new { @class = "page-link" });
        }


        private static bool ModeEnabled(WebGridPagerModes mode, WebGridPagerModes modeCheck)
        {
            return (mode & modeCheck) == modeCheck;
        }
    }
}