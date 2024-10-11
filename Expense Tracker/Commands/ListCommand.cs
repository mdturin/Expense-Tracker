using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class ListCommand : IArgsCommand
{
    public Command Execute()
    {
        var listCommand = new Command("list", "List all expenses");
        listCommand.SetHandler(() =>
        {
            var expenses = ExpenseManager.Instance.GetAll();
            Console.WriteLine("ID\tDate\t\tDescription\tAmount");
            expenses.ForEach(e => Console.WriteLine(e));
        });

        return listCommand;
    }
}
