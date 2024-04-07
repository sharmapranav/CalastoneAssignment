using System;
using System.Diagnostics.Metrics;
using static System.Net.Mime.MediaTypeNames;

namespace Calastone
{
    /// <summary>
    /// Filter3 – filter out words that contains the letter ‘t’ (by default)
    /// </summary>
    public class Filter3Letter : FilterCore, IFilter
    {
        readonly List<char> filterChars;

        public Filter3Letter(char letter = 't')
        {
            filterChars = new List<char>
            {
                letter
            };
        }

        public Filter3Letter(List<char> letters)
        {
            filterChars = letters;
        }

        /// <summary>
        /// Filters words that contain 't' (by default)
        /// </summary>
        /// <param name="text">Text to filter</param>
        /// <param name="stripAllSpecialCharacters">Optional flag to not strip special characters before running filter check</param>
        /// <returns>Filter word or empty string</returns>
        public string Filter(string text, bool stripAllSpecialCharacters = true)
        {
            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
            {
                string strippedText = stripAllSpecialCharacters ? StripAllSpecialCharacters(text) : text;
                if (strippedText.Length > 0)
                {
                    foreach (char filterChar in filterChars)
                    {
                        if (strippedText.Contains(filterChar))
                        {
                            return PreseveStartAndEndSpecialCharacters(text);
                        }
                    }
                    return text;
                }
            }
            return text;
        }
    }
}
