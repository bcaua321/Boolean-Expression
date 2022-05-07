using MinTermo.FileContext;

namespace MinTermo.TableContext;

public class Expression
{
    private string? _finalExpression;
    private static string[] letras = new string[] {"A", "B", "C", "D", "E", "F", "G" };
    public void Run()
    {
        ReadFile rf = new ReadFile();
        ReadExitTable rt = new ReadExitTable(rf.Content);
        Table table = new Table(rt.NumbersLength);
        CreateExpression(table._table, rt.Matches);
        Console.WriteLine($"Expressao final: {_finalExpression}");
    }
    
    public void CreateExpression(List<List<string>> table, List<string> content)
    {
        for (int i = 0; i < content.Count; i++)
        {
            if (content[i] == "0")
            {
                continue;
            }

            content[i] = " ";
            for (int j = 0; j < table.Count; j++)
            {
                if (table[j][i] == "0")
                {
                    content[i] += letras[j] + "'";
                }
                else
                {
                    content[i] += letras[j];
                }
            }
        }

        content.RemoveAll(x => x == "0");
        _finalExpression = string.Join(" + ", content);
    }
}