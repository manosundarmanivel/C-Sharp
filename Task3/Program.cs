using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> items = new List<string>();
        bool running = true;

        Console.WriteLine("Welcome to the List Manager!");
        Console.WriteLine("Commands: ADD, REMOVE, DISPLAY, EXIT");

        while (running)
        {
            Console.Write("\nEnter command: ");
            string command = Console.ReadLine().Trim().ToUpper();

            switch (command)
            {
                case "ADD":
                    Console.Write("Enter item to add: ");
                    string addItem = Console.ReadLine().Trim();
                    items.Add(addItem);
                    Console.WriteLine($"'{addItem}' added to the list.");
                    break;

                case "REMOVE":
                    Console.Write("Enter item to remove: ");
                    string removeItem = Console.ReadLine().Trim();
                    if (items.Remove(removeItem))
                    {
                        Console.WriteLine($"'{removeItem}' removed from the list.");
                    }
                    else
                    {
                        Console.WriteLine($"Item '{removeItem}' not found.");
                    }
                    break;

                case "DISPLAY":
                    Console.WriteLine("\nCurrent items in the list:");
                    if (items.Count == 0)
                    {
                        Console.WriteLine("The list is empty.");
                    }
                    else
                    {
                        foreach (var item in items)
                        {
                            Console.WriteLine($"- {item}");
                        }
                    }
                    break;

                case "EXIT":
                    running = false;
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }
        }
    }
}
