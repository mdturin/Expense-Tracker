using Expense_Tracker.Abstractions;
using Expense_Tracker.Services;

namespace Expense_Tracker.Exporter;

public class JsonExporter : AExporter
{
    public override void DoExport(string filePath)
    {
        var expenses = ExpenseManager.Instance.GetAll();
        StoreService.Write(expenses, filePath);
    }
}
