using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class SummaryCommand : IArgsCommand
{
    public Command Execute()
    {
        var summaryCommand = new Command("summary", "Total expenses");
        summaryCommand.SetHandler(() =>
        {
            var totalAmmount = ExpenseManager.Instance.Summary();
            Console.WriteLine($"Total expenses: {totalAmmount}");
        });

        return summaryCommand;
    }
}
