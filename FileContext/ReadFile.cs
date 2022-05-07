using System;
namespace MinTermo.FileContext;

public class ReadFile
{
    public string? Content { get; set; }
    private string[]? ContentArray { get; set; }
    private string? Path { get; set; }

    public ReadFile()
    {
        GetFile();
    }

    private void GetFile()
    {
        Console.WriteLine("Insert the path of file: ");
        Console.WriteLine(@"Example windows: c:\temp\test.txt");
        Console.WriteLine(@"Example linux/unix: /home/test.txt");
        Path = Console.ReadLine();
        Read();
    }

    private void Read()
    {
        if (!File.Exists(Path))
        {
            Console.WriteLine(Path);
            Console.WriteLine("It's not possible to find the file or the file doesn't exists");
            return;
        }

        ContentArray = File.ReadAllText(Path).Split(' ', '\n');
        Content = String.Join("", ContentArray);
    }
}