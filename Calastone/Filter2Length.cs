using System;
namespace Calastone
{
    /// <summary>
    /// Filter2 – filter out words that have length less than 3 (by default)
    /// </summary>
    public class Filter2Length : FilterCore, IFilter
    {
        private readonly int MinLength;

        public Filter2Length(int minLength = 3)
        {
            MinLength = minLength;
        }

        /// <summary>
        /// Filters words less than minlength 3 (by default)
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
                    if (strippedText.Length < MinLength)
                    {
                        return PreseveStartAndEndSpecialCharacters(text);
                    }
                    else
                    {
                        return text;
                    }
                }
            }
            return text;
        }
    }
}

