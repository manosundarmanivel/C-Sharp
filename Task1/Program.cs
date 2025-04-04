using System;

class Program
{
    static long CalculateFactorial(int n)
    {
        long result = 1; 
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine("A Simple Factorial Calculator");
        Console.Write("Enter a positive integer: ");
        
        string input = Console.ReadLine();

        if (int.TryParse(input, out int number) && number >= 0)
        {
            long factorial = CalculateFactorial(number);
            Console.WriteLine($"Factorial of {number} is = {factorial}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a non-negative integer.");
        }
    }
}
