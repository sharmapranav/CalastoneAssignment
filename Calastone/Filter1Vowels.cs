using System;
namespace Calastone
{
    /// <summary>
    /// Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather" should not be)
    /// </summary>
    public class Filter1Vowels : FilterCore, IFilter
    {
        readonly List<char> Vowels;

        public Filter1Vowels()
        {
            Vowels = new() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        }

        public Filter1Vowels(List<char> vowels)
        {
            Vowels = vowels;
        }

        /// <summary>
        /// Filters words with vowels in middle
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
                    int middleIndex = strippedText.Length / 2;
                    if (strippedText.Length % 2 != 0)
                    {
                        char middleChar = strippedText[middleIndex];
                        if (Vowels.Contains(middleChar))
                        {
                            return PreseveStartAndEndSpecialCharacters(text);
                        }
                        else
                        {
                            return text;
                        }
                    }
                    else
                    {
                        char middleChar = strippedText[middleIndex];
                        char middlePrevChar = strippedText[middleIndex - 1];
                        if (Vowels.Contains(middleChar) || Vowels.Contains(middlePrevChar))
                        {
                            return PreseveStartAndEndSpecialCharacters(text);
                        }
                        else
                        {
                            return text;
                        }
                    }
                }
            }
            return text;
        }
    }
}

