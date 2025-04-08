using System;
using System.Reflection;
using System.IO;


[AttributeUsage(AttributeTargets.Method)]
public class RunnableAttribute : Attribute
{
    public string Description { get; }

    public RunnableAttribute(string description)
    {
        Description = description;
    }
}


public class FileCommands
{
    [Runnable("List all files in the current directory")]
    public void ListFiles()
    {
        Console.WriteLine("Files in current directory:");
        string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
        foreach (string file in files)
        {
            Console.WriteLine(file);
        }
    }
}

public class SystemCommands
{
    [Runnable("Show current system time")]
    public void ShowTime()
    {
        Console.WriteLine($"System Time: {DateTime.Now}");
    }
}


public class CommandRunner
{
    public void RunAllRunnables()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            if (!type.IsClass || type.IsSubclassOf(typeof(Attribute)))
                continue;
                
            var instance = Activator.CreateInstance(type);
            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);

            foreach (var method in methods)
            {
                var runnable = method.GetCustomAttribute<RunnableAttribute>();
                if (runnable != null)
                {
                    Console.WriteLine($"\n==> Running: {method.Name} - {runnable.Description}");
                    method.Invoke(instance, null);
                }
            }
        }
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("== Running All Runnable Commands ==");
        var runner = new CommandRunner();
        runner.RunAllRunnables();
    }
}
