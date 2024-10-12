using Expense_Tracker.Exporter;
using Expense_Tracker.Interfaces;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class ExportCommand : IArgsCommand
{
    public Command Execute()
    {
        var typeOption = new Option<string>(["--type", "type"], () => "json", "Export Type: 'JSON', 'XLSL', 'CSV'") { IsRequired = false };
        var nameOption = new Option<string>(["--name", "name"], () => "expenses", "Export file name") { IsRequired = false };

        var exportCommand = new Command("export", "Export expense tracker")
        {
            typeOption,
            nameOption
        };

        exportCommand.SetHandler((string type, string name) =>
        {
            var exporter = GetExporter(type);
            name = Path.ChangeExtension(name, type);
            exporter.Export(name);
        }, typeOption, nameOption);

        return exportCommand;
    }

    public static IExporter GetExporter(string type)
    {
        return type.ToLower() switch
        {
            "json" => new JsonExporter(),
            "csv" => new CsvExporter(),
            "excel" => new ExcelExporter(),
            _ => throw new NotImplementedException()
        };
    }
}
