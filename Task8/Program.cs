using System;
using System.Collections.Generic;


public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
}


public interface IRepository<T> where T : class
{
    void Add(int id, T item);
    T Get(int id);
    List<T> GetAll();
    void Update(int id, T item);
    void Delete(int id);
}


public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private Dictionary<int, T> _items = new Dictionary<int, T>();

    public void Add(int id, T item)
    {
        if (!_items.ContainsKey(id))
            _items.Add(id, item);
    }

    public T Get(int id)
    {
        _items.TryGetValue(id, out T item);
        return item;
    }

    public List<T> GetAll()
    {
        return new List<T>(_items.Values);
    }

    public void Update(int id, T item)
    {
        if (_items.ContainsKey(id))
            _items[id] = item;
    }

    public void Delete(int id)
    {
        if (_items.ContainsKey(id))
            _items.Remove(id);
    }
}

// Step 4: Use the Repository in a Console UI
class Program
{
    static void Main(string[] args)
    {
        IRepository<Student> studentRepo = new InMemoryRepository<Student>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- Student Repository Menu ---");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Get Student by ID");
            Console.WriteLine("3. List All Students");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    studentRepo.Add(id, new Student { Id = id, Name = name });
                    break;

                case "2":
                    Console.Write("Enter ID to fetch: ");
                    int getId = int.Parse(Console.ReadLine());
                    var student = studentRepo.Get(getId);
                    Console.WriteLine(student != null ? $"ID: {student.Id}, Name: {student.Name}" : "Student not found.");
                    break;

                case "3":
                    var allStudents = studentRepo.GetAll();
                    foreach (var s in allStudents)
                        Console.WriteLine($"ID: {s.Id}, Name: {s.Name}");
                    break;

                case "4":
                    Console.Write("Enter ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter New Name: ");
                    string newName = Console.ReadLine();
                    studentRepo.Update(updateId, new Student { Id = updateId, Name = newName });
                    break;

                case "5":
                    Console.Write("Enter ID to delete: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    studentRepo.Delete(deleteId);
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }

        Console.WriteLine("Application ended. Press any key to exit.");
        Console.ReadKey();
    }
}
