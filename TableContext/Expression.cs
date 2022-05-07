using MinTermo.FileContext;

namespace MinTermo.TableContext;

public class Expression
{
    private string? _finalExpression;
    private static string[] _letras = new string[] {"A", "B", "C", "D", "E", "F", "G" };
    public void Run()
    {
        ReadFile rf = new ReadFile();
        ReadExitTable rt = new ReadExitTable(rf.Content);
        Table table = new Table(rt.NumbersLength);
        Console.WriteLine($"tabela: ");
        PrintTruthTable(table._table, rt.Matches);
        CreateExpression(table._table, rt.Matches);
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
                    content[i] += _letras[j] + "'";
                }
                else
                {
                    content[i] += _letras[j];
                }
            }
        }

        content.RemoveAll(x => x == "0");
        _finalExpression = string.Join(" + ", content);
        Console.WriteLine($"Final Expression: {_finalExpression}");
    }

    public void PrintTruthTable(List<List<string>> table, List<string> lista)
    {
        Console.WriteLine("Table");
        for (int i = 0; i < lista.Count; i++)
        {
            for (int j = 0; j < table.Count; j++)
            {
                Console.Write($"{table[j][i]: j + 2} ");
            }
            
            Console.WriteLine(lista[i]);
        }
    }
}