using System;
using System.Reflection;
using Calastone;

namespace Calastone.MSTests;

[TestClass]
public class FileReaderUnitTests
{
    readonly FileReader fileReader;

    public FileReaderUnitTests()
    {
        fileReader = new FileReader();
    }

    [TestMethod]
    public void TestFileRead()
    {
        string? folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        if (folder != null)
        {
            string filename = Path.Combine(folder, @"Input.txt");
            string text = fileReader.ReadFile(filename);
            Assert.IsTrue(text.Length > 0);
        }
    }

    [TestMethod]
    public void TestFileError()
    {
        string filename = "NoFile.txt";
        string text = fileReader.ReadFile(filename);
        Assert.IsTrue(text == string.Empty);
    }
}
