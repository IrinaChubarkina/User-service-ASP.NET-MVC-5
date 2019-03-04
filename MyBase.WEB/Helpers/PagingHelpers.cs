﻿using MyBase.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
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
            if (pageInfo.PageNumber == 1)
            {
                startNumber = 1;
            }
            else
            {
                startNumber = (int)pageInfo.PageNumber - 1;
            };
            if (pageInfo.PageNumber == pageInfo.TotalPages)
            {
                lastNumber = pageInfo.TotalPages;
            }
            else
            {
                lastNumber = startNumber + 2;
            };
            StringBuilder result = new StringBuilder();
            for (int i = startNumber; i <= lastNumber; i++)
            {
                TagBuilder tag = new TagBuilder("a");
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