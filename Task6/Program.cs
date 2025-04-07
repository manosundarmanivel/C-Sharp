using System;

namespace Task6_EventDrivenCounter
{

    public delegate void ThresholdReachedHandler(int count);

   
    public class Counter
    {
        private int _count = 0;
        private readonly int _threshold;

        
        public event ThresholdReachedHandler? ThresholdReached;

        public Counter(int threshold)
        {
            _threshold = threshold;
        }

        public void Increment()
        {
            _count++;
            Console.WriteLine($"Current Count: {_count}");

            if (_count == _threshold)
            {
            
                ThresholdReached?.Invoke(_count);
            }
        }
    }

    class Program
    {
  
        static void AlertUser(int count)
        {
            Console.WriteLine($"Alert: Counter reached {count}!");
        }

        static void LogToConsole(int count)
        {
            Console.WriteLine($"Log: Event triggered at count {count}.");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Event-driven Counter Example");

            Counter counter = new Counter(5);

           
            counter.ThresholdReached += AlertUser;
            counter.ThresholdReached += LogToConsole;

            Console.WriteLine("Press any key to increment the counter...");
            for (int i = 0; i < 10; i++)
            {
                Console.ReadKey();
                counter.Increment();
            }

            Console.WriteLine("Program completed. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
