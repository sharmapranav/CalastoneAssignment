using System;
using System.Security;

namespace Calastone
{
    /// <summary>
    /// Read from a txt file
    /// </summary>
    public class FileReader
    {
        /// <summary>
        /// Reads file contents of the filename provided
        /// </summary>
        /// <param name="filename"></param>
        /// <returns>File contents if file found or empty string</returns>
        public string ReadFile(string filename)
        {
            try
            {
                return File.ReadAllText(filename);
            }
            catch (ArgumentNullException)
            {
                Console.Error.WriteLine("path is null.");
            }
            catch (ArgumentException)
            {
                Console.Error.WriteLine(".NET Framework and .NET Core versions older than 2.1: path is a zero-length string, contains only white space, or contains one or more invalid characters. You can query for invalid characters by using the GetInvalidPathChars() method.");
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("The file specified in path was not found.");
            }
            catch (PathTooLongException)
            {
                Console.Error.WriteLine("The specified path, file name, or both exceed the system-defined maximum length.");
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("The specified path is invalid (for example, it is on an unmapped drive).");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("An I/O error occurred while opening the file.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.Error.WriteLine("path specified a file that is read-only.\n-or-\nThis operation is not supported on the current platform.\n-or-\npath specified a directory.\n-or-\nThe caller does not have the required permission.");
            }
            catch (NotSupportedException)
            {
                Console.Error.WriteLine("path is in an invalid format.");
            }
            catch (SecurityException)
            {
                Console.Error.WriteLine("The caller does not have the required permission.");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
            return string.Empty;
        }
    }
}

