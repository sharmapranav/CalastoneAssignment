using System.Drawing;

namespace Calastone.MSTests;

/// <summary>
/// Filter2 – filter out words that have length less than 3
/// </summary>
[TestClass]
public class Filter2LengthUnitTests
{
    readonly Filter2Length filter2Length;

    public Filter2LengthUnitTests()
    {
        filter2Length = new Filter2Length();
    }

    [TestMethod]
    public void TestSimpleDeny()
    {
        List<string> wordList = new()
        {
            "a",
            "at",
            "be",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterInWordDeny()
    {
        List<string> wordList = new()
        {
            "i'm",
            "c*n"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterStartEndDeny()
    {
        string word = "i.";
        Assert.AreEqual(filter2Length.Filter(word), ".", $"Assertion Failed: {word}");
        Assert.AreEqual(filter2Length.Filter(word.ToUpper()), ".", $"Assertion Failed: {word}");
        word = "im!";
        Assert.AreEqual(filter2Length.Filter(word), "!", $"Assertion Failed: {word}");
        Assert.AreEqual(filter2Length.Filter(word.ToUpper()), "!", $"Assertion Failed: {word}");
    }

    [TestMethod]
    public void TestNumbersDeny()
    {
        List<string> wordList = new()
        {
            "o1",
            "2a",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersOnlyDeny()
    {
        List<string> wordList = new()
        {
            "1",
            "1.1",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSimpleAllow()
    {
        List<string> wordList = new()
        {
            "the",
            "myth",
            "rather"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterAllow()
    {
        List<string> wordList = new()
        {
            "at&t",
            "tb-bt",
            "ad-hoc",
            "sun-set",
            "whyt?"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersAllow()
    {
        List<string> wordList = new()
        {
            "b2t",
            "h2o",
            "at3t",
            "tb4bt",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersOnlyAllow()
    {
        List<string> wordList = new()
        {
            "123",
            "-123",
            "12.2",
            "-12.2",
            "$12.3",
            "#12345",
            "$123456",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharactersOnlyAllow()
    {
        List<string> wordList = new()
        {
            ".",
            "..",
            "!!!",
            "@@@@",
            "#####",
            "$$$$$$"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNullWhitespace()
    {
        List<string> wordList = new()
        {
            null,
            " ",
            "\t",
            "\n",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter2Length.Filter(word), word, $"Assertion Failed: {word}");
        }
    }
}
