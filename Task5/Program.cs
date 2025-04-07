using System;
using System.IO;

namespace Task5 {
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "students.csv";
            string outputFilePath = "result.txt";
            int lineCount =0;
            int wordCount = 0;

            try
            {

                using(StreamReader reader = new StreamReader(inputFilePath))
                {
                    string? line;
                    while((line = reader.ReadLine())!= null)
                    {
                        lineCount++;
                        string[] words = line.Split(',', StringSplitOptions.RemoveEmptyEntries);
                        wordCount += words.Length;

                    }
                }

                Console.WriteLine($"Total lines: {lineCount}");
                Console.WriteLine($"Total words: {wordCount}");
              
                using(StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    writer.WriteLine($"Total lines: {lineCount}");
                    writer.WriteLine($"Total words: {wordCount}");
                    writer.WriteLine("Processing completed successfully.");
                }

                Console.WriteLine($"Results written to {outputFilePath}");
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Processing completed.");
            }
            
        }
    }
}
