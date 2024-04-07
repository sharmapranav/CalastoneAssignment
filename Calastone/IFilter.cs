using System;
namespace Calastone
{
    /// <summary>
    /// Interface all filters classes implement to standardise implementation
    /// </summary>
    public interface IFilter
    {
        string Filter(string text, bool stripAllSpecialCharacters = true);
    }
}

