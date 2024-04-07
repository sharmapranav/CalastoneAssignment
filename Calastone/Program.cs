using System;
using System.Reflection;

namespace Calastone
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = string.Empty;
            string? folder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (folder != null)
            {
                filename = Path.Combine(folder, @"Input.txt");
            }

            if (args.Length < 1)
            {
                Console.WriteLine("Press enter to use default project file OR Input full file name with path to process");
                string? filenameConsole = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(filenameConsole) && !string.IsNullOrWhiteSpace(filenameConsole))
                {
                    filename = filenameConsole;
                }
            }
            else
            {
                filename = args[0].ToString();
            }

            List<string> fileWords;
            FileReader fileReader = new();
            string fileText = fileReader.ReadFile(filename);
            if (!string.IsNullOrWhiteSpace(fileText) && !string.IsNullOrWhiteSpace(fileText))
            {
                fileWords = fileText.Split(new char[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (fileWords.Any())
                {
                    List<string> unfilteredWords = new();
                    Filter1Vowels filter1Vowels = new();
                    Filter2Length filter2Length = new();
                    Filter3Letter filter3Letter = new();

                    foreach (string word in fileWords)
                    {
                        string filteredWord = word;
                        filteredWord = filter1Vowels.Filter(filteredWord);
                        filteredWord = filter2Length.Filter(filteredWord);
                        filteredWord = filter3Letter.Filter(filteredWord);

                        if (!string.IsNullOrEmpty(filteredWord) && !string.IsNullOrWhiteSpace(filteredWord))
                        {
                            unfilteredWords.Add(word);
                        }
                    }
                    Console.WriteLine("Output\n");
                    Console.WriteLine(string.Join(' ', unfilteredWords));
                }
            }
        }
    }
}
