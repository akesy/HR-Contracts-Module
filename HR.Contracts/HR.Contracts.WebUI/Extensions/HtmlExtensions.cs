using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using HR.Contracts.Shared.Enums;
using HR.Contracts.WebUI.Models;

namespace HR.Contracts.WebUI.Extensions
{
    public static class HtmlExtensions
    {
        private const string CurrentPageSelectedCssClass = "active";
        private const string PaginationContainerCssClass = "pagination";

        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                var li = new TagBuilder("li");
                var a = new TagBuilder("a");
                a.MergeAttribute("href", pageUrl(i));
                a.InnerHtml = i.ToString();
                li.InnerHtml = a.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    li.AddCssClass(CurrentPageSelectedCssClass);
                }

                result.Append(li.ToString());
            }

            var ul = new TagBuilder("ul");
            ul.AddCssClass(PaginationContainerCssClass);
            ul.InnerHtml = result.ToString();

            return MvcHtmlString.Create(ul.ToString());
        }

        public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue)
        {
            return ToSelectList(enumValue, new SelectListOptions());
        }

        public static IEnumerable<SelectListItem> ToSelectList(this Enum enumValue, SelectListOptions options)
        {
            return LocalizedEnumConverter.GetValues(enumValue.GetType(), CultureInfo.CurrentCulture)
                .Where(e => !options.IgnoredValues.Contains(e.Key))
                .Select(e => new SelectListItem()
                {
                    Selected = options.SelectChosenValue && e.Key.Equals(enumValue),
                    Text = e.Value,
                    Value = options.EnforceNumericValues ? Convert.ToInt32(e.Key, CultureInfo.InvariantCulture).ToString(CultureInfo.CurrentCulture) :
                   e.Key.ToString()
                });
        }
    }
}