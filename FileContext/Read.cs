namespace MinTermo.FileContext;

public class Read
{
    public void Initialize()
    {
        ReadFile.GetFile();
        ReadFile.Read();
        ReadExitTable rt = new ReadExitTable();
        rt.ReadBinary();
    }
}