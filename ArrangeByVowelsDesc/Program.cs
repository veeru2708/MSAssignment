using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ArrangeByVowelsDesc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path of the file to process");
            string inputFilePath = Console.ReadLine();
            var result = ArrangeSentencesByVowelCountDesc(inputFilePath);
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }

        /// <summary>
        /// This method takes a file as input.
        /// Analyzes the contents of the file, and arranges the sentences based on the number of vowels in the ascending order.
        /// </summary>
        /// <param name="filePath">input file path</param>
        /// <returns>true if the process is successfull or false if there is any exception or file not found</returns>
        private static bool ArrangeSentencesByVowelCountDesc(string filePath)
        {

            if (File.Exists(filePath))
            {
                try
                {
                    string text = System.IO.File.ReadAllText(filePath);
                    var path = Directory.GetParent(filePath);
                    var fileName = Path.GetFileNameWithoutExtension(filePath);

                    var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u' };
                    var result = text.Split('.').Select(x => new { vowelCount = x.ToLower().Count(c => vowels.Contains(c)), Sentence = x }).OrderByDescending(x => x.vowelCount);
                    var resultString = string.Join('.', result.Select(x => x.Sentence));
                    System.IO.File.WriteAllText($"{path}\\{fileName}_Result.txt", resultString);
                    Console.WriteLine("Input file processed successfully!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error encountered while processing the file. Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("File does not exists!");
            }
            return false;
        }
    }
}
