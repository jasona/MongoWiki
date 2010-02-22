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

        public static List<KeyValuePair<string,string>> ParseWordLinks(string text)
        {
            List<KeyValuePair<string, string>> links = new List<KeyValuePair<string, string>>();


            foreach (var match in Regex.Matches(text, @"((^\s*|\s+)([A-Z][a-z]+){2,}|(?<=[^\.""]\s+)[A-Z][a-z]\w*(?=(\s+|\.)))"))
            {
                string hyphenated = HyphenatePascalCasedWords(match.ToString());

                KeyValuePair<string, string> link = new KeyValuePair<string, string>(match.ToString().Trim(), hyphenated);

                links.Add(link);

            }

            return links;
        }

        public static string HyphenatePascalCasedWords(string text)
        {
            var sb = new StringBuilder();
            var firstWord = true;

            foreach (var match in Regex.Matches(text, "([A-Z][a-z]+)|[0-9]+"))
            {
                if (firstWord)
                {
                    sb.Append(match.ToString().ToLower());
                    firstWord = false;
                }
                else
                {
                    sb.Append("-");
                    sb.Append(match.ToString().ToLower());
                }
            }

            return sb.ToString();
        }

    }
}
