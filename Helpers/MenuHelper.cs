using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace kursovik.Helpers
{
    public static class MenuHelper
    {

        public static string Menu(this HtmlHelper helper)
        {
            var sb = new StringBuilder();
            sb.Append("<ul id='menu'>");
            var topLevelNodes = SiteMap.RootNode.ChildNodes;
            foreach (SiteMapNode node in topLevelNodes)

            {
                if (SiteMap.CurrentNode == node)
                    sb.AppendLine("<li class='selectedMenuItem'>");
                else
                    sb.AppendLine("<li>");
                sb.AppendFormat("<a href='{0}' title='{1}'>{2}</a>",
               node.Url, helper.Encode(node.Description), helper.Encode(node.Title));
                sb.AppendLine("</li>");
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
    }
}