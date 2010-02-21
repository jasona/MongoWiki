using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

namespace MongoWiki.Lib
{
    public class Utility
    {
        private Utility() { }

        public static string UnFormatForUrl(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Replace("-", " ");
        }

        public static string FormatForUrl(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new ArgumentNullException("text", "Text to clean is null or empty");

            text = Regex.Replace(text.ToLower(), "[^A-Za-z0-9-]+", "-", RegexOptions.IgnoreCase);
            text = Regex.Replace(text.ToLower(), "[-]{2,}", "-", RegexOptions.IgnoreCase);

            if (text.StartsWith("-"))
                text = text.Substring(1);

            if (text.EndsWith("-"))
                text = text.Substring(0, text.Length - 1);

            return text;
        }

        public static string ScrubPageUrl(string text)
        {
            string output = text;

            output = output.ToLower();
            output = output.Trim();
            output = HttpUtility.HtmlDecode(output);

            return output;
        }

    }
}
