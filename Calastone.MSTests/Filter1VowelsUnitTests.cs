using System.Drawing;

namespace Calastone.MSTests;

/// <summary>
/// Filter1 – filter out all the words that contains a vowel in the middle of the word – the centre 1 or 2 letters
/// ("clean" middle is ‘e’, "what" middle is ‘ha’, "currently" middle is ‘e’ and should be filtered, "the", "rather"
/// should not be)
/// </summary>
[TestClass]
public class Filter1VowelsUnitTests
{
    readonly Filter1Vowels filter1Vowels;

    public Filter1VowelsUnitTests()
    {
        filter1Vowels = new Filter1Vowels();
    }

    [TestMethod]
    public void TestSimpleDeny()
    {
        List<string> wordList = new()
        {
            "a",
            "at",
            "be",
            "bee",
            "bet",
            "bump",
            "idea",
            "clean",
            "what",
            "booed",
            "booked",
            "currently",
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterInWordDeny()
    {
        List<string> wordList = new()
        {
            "a&t",
            "i'am",
            "pot'd",
            "can't",
            "ad-ooo",
            "hoo-hoo"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterStartEndDeny()
    {
        string word = "i.";
        Assert.AreEqual(filter1Vowels.Filter(word), ".", $"Assertion Failed: {word}");
        Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), ".", $"Assertion Failed: {word}");
        word = "im!";
        Assert.AreEqual(filter1Vowels.Filter(word), "!", $"Assertion Failed: {word}");
        Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), "!", $"Assertion Failed: {word}");
        word = "?iam";
        Assert.AreEqual(filter1Vowels.Filter(word), "?", $"Assertion Failed: {word}");
        Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), "?", $"Assertion Failed: {word}");
        word = "boat.";
        Assert.AreEqual(filter1Vowels.Filter(word), ".", $"Assertion Failed: {word}");
        Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), ".", $"Assertion Failed: {word}");
    }

    [TestMethod]
    public void TestNumbersDeny()
    {
        List<string> wordList = new()
        {
            "o1",
            "2at",
            "1im",
            "1potd",
            "boat",
            "3cant",
            "a4ahoc",
            "h0oho0"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), string.Empty, $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), string.Empty, $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSimpleAllow()
    {
        List<string> wordList = new()
        {
            "b",
            "my",
            "the",
            "myth",
            "rather"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestSpecialCharacterAllow()
    {
        List<string> wordList = new()
        {
            "b.",
            "b-t",
            "at&t",
            "tb-bt",
            "ad-hoc",
            "sun-set",
            "whyt?"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
        }
    }

    [TestMethod]
    public void TestNumbersAllow()
    {
        List<string> wordList = new()
        {
            "b1",
            "b2t",
            "h2o",
            "at3t",
            "tb4bt",
            "adh0c",
            "5unset"
        };

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
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

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
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

        // Lower case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToLower()), word.ToLower(), $"Assertion Failed: {word}");
        }

        // Upper case
        foreach (string word in wordList)
        {
            Assert.AreEqual(filter1Vowels.Filter(word.ToUpper()), word.ToUpper(), $"Assertion Failed: {word}");
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
            Assert.AreEqual(filter1Vowels.Filter(word), word, $"Assertion Failed: {word}");
        }
    }
}