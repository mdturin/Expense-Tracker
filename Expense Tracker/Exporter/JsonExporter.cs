using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;

namespace Expense_Tracker.Exporter;

public class JsonExporter : IExporter
{
    public void Export(string fileName)
    {
        var expenses = ExpenseManager.Instance.GetAll();

    }
}
