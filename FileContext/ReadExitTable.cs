using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace MinTermo.FileContext;

public class ReadExitTable 
{ 
    public List<string> Matches { get; }
    public int NumbersLength => Matches.Count();
    private readonly Regex _erInvalid = new Regex(@"[^01]");
    private readonly Regex _erValid = new Regex(@"[01]");

    public ReadExitTable(string? content)
    {
        Matches = new List<string>();
        ReadBinary(content);
    }
    
    private bool IsInvalid(string? content)
    {
        if(content == null)
        {
            return true;
        }

        return _erInvalid.IsMatch(content);
    }

    private void ReadBinary(string? content)
    {
        if (IsInvalid(content))
        {
            Console.WriteLine("O arquivo está vazio ou foi preenchido de forma irregular");
            return;
        }

        MatchCollection mc = _erValid.Matches(content);

        foreach (Match match in mc)
        {
            Matches.Add(match.Value);
        }
        
    }
}