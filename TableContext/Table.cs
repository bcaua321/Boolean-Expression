namespace MinTermo.TableContext;

public class Table
{
    private int _size;
    private int _column;
    public List<List<string>>? _table;

    public Table(int size)
    {
        _size = size;
        _table = new List<List<string>>();
        CreateTable();
    }

    private bool AcceptedTable(int size)
    {
        int elements = 0;
        for (int i = 2; i <= size / 2; i++)
        {
            elements =(int)Math.Pow(2, i);
            if (elements == size)
            {
                _column = i;
                break;
            }
        }

        return size == elements;
    }

    public void CreateTable()
    {
        if (!AcceptedTable(_size))
        {
            Console.WriteLine("A tabela é imcopatível!");
            return;
        }
        
        _table = new List<List<string>>(_column);
        List<string>? listElement;

        for (int i = 0; i < _column; i++)
        {
            listElement = new List<string>();
            while (listElement.Count < Math.Pow(2, _column))
            {
                int k;
                for (k = 0; k < _size / 2; k++)
                {
                    listElement.Add("0");
                }
                
                for (; k < _size; k++)
                {
                    listElement.Add("1");
                }
            }

            _size /=  2;
            _table.Add(listElement);
        }

        foreach (List<string> list in _table)
        {
            foreach (string item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine("\n");
        }
    }
    
}