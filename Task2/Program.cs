using System;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }

    public void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name}. I am {Age} years old.");
        Console.WriteLine($"I live at {Address}.");
        Console.WriteLine($"You can reach me at {PhoneNumber} or {Email}.");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Person person1 = new Person
        {
            Name = "Mano ",
            Age = 30,
            Address = "123 Main St, Springfield",
            PhoneNumber = "555-1234",
            Email = "mano@gmail.com"
        };

        Person person2 = new Person
        {
            Name = "Sundar",   
            Age = 25,
            Address = "456 Elm St, Springfield",
            PhoneNumber = "555-5678", 
            Email = "sundar4834@gmail.com"  
        };

        Person person3 = new Person 
        {
            Name = "Ravi",
            Age = 28,
            Address = "789 Oak St, Springfield",
            PhoneNumber = "555-9012",   
            Email= "ravi@hmail.com"
        };

        person1.Introduce();
        person2.Introduce();
        person3.Introduce();
        
    }
}
