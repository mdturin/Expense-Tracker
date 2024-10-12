using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;

namespace Expense_Tracker.Abstractions;

public abstract class AExporter : IExporter
{
    public void Export(string fileName)
    {
        var documentsPath = string.Empty;
        if (ConfigurationService.Instance.Contains("StorePath"))
            documentsPath = ConfigurationService.Instance.GetConfig("StorePath");
        else
            documentsPath = Environment
            .GetFolderPath(Environment.SpecialFolder.MyDocuments);

        var filePath = Path.Combine(documentsPath, fileName);

        DoExport(filePath);

        Console.WriteLine("File has been created successfully at: " + filePath);
    }

    public abstract void DoExport(string filePath);
}
