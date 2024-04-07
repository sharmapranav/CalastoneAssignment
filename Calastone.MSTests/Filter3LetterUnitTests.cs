using System.Drawing;

namespace Calastone.MSTests;

/// <summary>
/// Filter3 – filter out words that contains the letter ‘t’
/// </summary>
[TestClass]
public class Filter3LetterUnitTests
{
    readonly Filter3Letter filter3Letter;

    public Filter3LetterUnitTests()
    {
        filter3Letter = new Filter3Letter();
    }

    [TestMethod]
    public void TestSimpleDeny()
    {
        List<string> wordList = new()
        {
            "t",
            "at",
            "bet",
            "beet",
            "burnt",
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterInWordDeny()
    {
        List<string> wordList = new()
        {
            "a&t",
            "t'am",
            "pot'd",
            "can't",
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterStartEndDeny()
    {
        string word = "t.";
        Assert.AreEqual(filter3Letter.Filter(word), ".", $"Assertion Failed: {word}");
        word = "ti!";
        Assert.AreEqual(filter3Letter.Filter(word), "!", $"Assertion Failed: {word}");
        word = "?tam";
        Assert.AreEqual(filter3Letter.Filter(word), "?", $"Assertion Failed: {word}");
        word = "boat.";
        Assert.AreEqual(filter3Letter.Filter(word), ".", $"Assertion Failed: {word}");
    }

    [TestMethod]
    public void TestNumbersDeny()
    {
        List<string> wordList = new()
        {
            "t1",
            "2at",
            "1tim",
            "1potd",
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSimpleAllow()
    {
        List<string> wordList = new()
        {
            "b",
            "T",
            "my",
            "him",
            "flew",
            "flown",
            "TBA",
            "Tap"
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterAllow()
    {
        List<string> wordList = new()
        {
            "b.",
            "b-a",
            "ab&b",
            "ab-ba",
            "ad-hoc",
            "Tik-Tok",
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersAllow()
    {
        List<string> wordList = new()
        {
            "T1",
            "2T",
            "b1",
            "b2b",
            "h2o",
            "l3af",
            "adh0c",
            "T2-B2"
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersOnlyAllow()
    {
        List<string> wordList = new()
        {
            "1",
            "-12",
            "-12.2",
            "$12.3",
            "#12345",
            "$123456",
            "1+2"
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharactersOnlyAllow()
    {
        List<string> wordList = new()
        {
            ".",
            "--",
            "!!!",
            "@@@@",
            "#####",
            "$$$$$$"
        };

        foreach (string word in wordList)
        {
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
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
            Assert.AreEqual(filter3Letter.Filter(word), word, $"Assertion Failed: {word}");
        }
    }
}
