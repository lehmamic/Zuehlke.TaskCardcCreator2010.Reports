﻿using System.Text.RegularExpressions;

namespace Zuehlke.TaskCardCreator.Reports.ScrumDetailed.Converters
{
    public static class HtmlRemoval
    {
        /// <summary>
        /// Remove HTML from string with Regex.
        /// </summary>
        public static string StripTagsRegex(string source)
        {
            string sourceString = Regex.Replace(source, "<P>", string.Empty);
            sourceString = Regex.Replace(sourceString, "\n", string.Empty);
            sourceString = Regex.Replace(sourceString, "</P>", "\r\n");
            sourceString = Regex.Replace(sourceString, "<BR>", "\r\n");
            sourceString = Regex.Replace(sourceString, "<.*?>", string.Empty);
            sourceString = Regex.Replace(sourceString, "&nbsp;", " ");
            sourceString = Regex.Replace(sourceString, "&lt;", string.Empty);
            sourceString = Regex.Replace(sourceString, "&gt;", string.Empty);

            return sourceString;
        }
    }
}