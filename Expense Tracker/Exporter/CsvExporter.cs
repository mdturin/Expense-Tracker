using Expense_Tracker.Abstractions;
using Expense_Tracker.Services;
using System.Text;

namespace Expense_Tracker.Exporter;

public class CsvExporter : AExporter
{
    public override void DoExport(string filePath)
    {
        var csv = new StringBuilder();
        var expenses = ExpenseManager.Instance.GetAll();

        // Add CSV header
        csv.AppendLine("Id,Date,Description,Amount");

        // Add rows for each expense
        foreach (var expense in expenses)
        {
            var newLine = $"{expense.Id},{expense.Date:yyyy-MM-dd},{expense.Description},{expense.Amount}";
            csv.AppendLine(newLine);
        }

        // Write the CSV content to the file
        File.WriteAllText(filePath, csv.ToString());
    }
}
