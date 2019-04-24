using MyBase.WEB.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace MyBase.WEB.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
            PageInfo pageInfo, Func<int, string> pageUrl)
        {
            int startNumber;
            int lastNumber;

            if (pageInfo.PageNumber <= 5)
            {
                startNumber = 1;
            }
            else
            {
                startNumber = pageInfo.PageNumber - 5;
            }

            if (pageInfo.PageNumber >= pageInfo.TotalPages - 5)
            {
                lastNumber = pageInfo.TotalPages;
            }
            else
            {
                lastNumber = startNumber + 9;
            }

            var result = new StringBuilder();
            for (var i = startNumber; i <= lastNumber; i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageInfo.PageNumber)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}