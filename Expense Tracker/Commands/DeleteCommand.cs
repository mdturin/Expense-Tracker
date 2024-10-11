using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class DeleteCommand : IArgsCommand
{
    public Command Execute()
    {
        var expenseIdOption = new Option<int>("--id", "Expense Id");
        var deleteCommand = new Command("delete", "Delete Expense")
        {
            expenseIdOption
        };

        deleteCommand.SetHandler((int expenseId) =>
        {
            if (ExpenseManager.Instance.DeleteExpense(expenseId))
            {
                ExpenseManager.Instance.SaveAll();
                Console.WriteLine("Expense deleted successfully");
            }
            else
            {
                Console.WriteLine("Expense delete failed!");
            }
        }, expenseIdOption);

        return deleteCommand;
    }
}
