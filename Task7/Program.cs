using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task7
{
    class Program 
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Fetching data from multiple sources...");

            try{
                var tasks = new List<Task<string>>
                {
                    FetchDataFromSource("Source 1", 2000),
                    FetchDataFromSource("Source 2", 3000),
                    FetchDataFromSource("Source 3", 4000),
                };

                var results = await Task.WhenAll(tasks);

                
                Console.WriteLine("\nAll Data Received");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }

            Console.WriteLine("\nDone. Press any key to exit.");
            Console.ReadKey();
        }

        static async Task<string> FetchDataFromSource(string sourceName, int delay)
        {
            Console.WriteLine($"[Started] Fetching from {sourceName}...");
            await Task.Delay(delay);
            return $"[Completed] Data from {sourceName} (after {delay}ms)"; 
        }
    }
}


