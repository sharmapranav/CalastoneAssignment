using System;
using System.Text.RegularExpressions;

namespace Calastone
{
    /// <summary>
    /// Base abstract class to share common method(s)
    /// </summary>
    public abstract partial class FilterCore
    {
        // https://learn.microsoft.com/en-us/dotnet/fundamentals/syslib-diagnostics/syslib1040-1049
        // https://www.meziantou.net/regex-source-generator.htm

        /// <summary>
        /// Regex to grep all special characters in text
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("[^0-9a-zA-Z]")]
        private static partial Regex AllSpecialCharacters();

        /// <summary>
        /// Regex to match all special characters at start & end of text
        /// </summary>
        /// <returns></returns>
        [GeneratedRegex("^[\\W_]+|[\\W_]+$")]
        private static partial Regex StartEndSpecialCharacters();

        /// <summary>
        /// Removes all special characters from a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string StripAllSpecialCharacters(string text)
        {
            if (!string.IsNullOrEmpty(text) & !string.IsNullOrWhiteSpace(text))
            {
                return AllSpecialCharacters().Replace(text, string.Empty);
            }
            return text;
        }

        /// <summary>
        /// Removes all characters except any special characters at begining and end of word
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string PreseveStartAndEndSpecialCharacters(string text)
        {
            if (!string.IsNullOrEmpty(text) & !string.IsNullOrWhiteSpace(text))
            {
                return StartEndSpecialCharacters().Match(text).ToString();
            }
            return text;
        }

        //public abstract string Filter(string text); // Replaced with IFilter interface
    }
}