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
        Console.WriteLine("Insira o caminho global do arquivo: ");
        Console.WriteLine(@"Exemplo ruindows: c:\temp\test.txt");
        Console.WriteLine(@"Exemplo linux/unix: /home/test.txt");
        Path = Console.ReadLine();
        Read();
    }

    private void Read()
    {
        if (!File.Exists(Path))
        {
            Console.WriteLine(Path);
            Console.WriteLine("Não foi possível encontrar o arquivo ou não existe");
            return;
        }

        ContentArray = File.ReadAllText(Path).Split(' ', '\n');
        Content = String.Join("", ContentArray);
        Console.WriteLine(Content);
    }
}