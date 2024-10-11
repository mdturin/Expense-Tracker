using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class AddCommand : IArgsCommand
{
    public Command Execute()
    {
        // Define the options for the add command
        var descriptionOption = new Option<string>("--description", "Description of the expense") { IsRequired = true };
        var amountOption = new Option<double>("--amount", "Amount of the expense") { IsRequired = true };

        // Command to add an expense
        var addCommand = new Command("add", "Add a new expense")
        {
            descriptionOption,
            amountOption
        };

        addCommand.SetHandler((string description, double amount) =>
        {
            var expense = ExpenseManager.Instance
                .CreateExpense(description, amount);
            ExpenseManager.Instance.SaveAll();
            Console.WriteLine($"Expense added successfully (ID: {expense.Id})");
        }, descriptionOption, amountOption);

        return addCommand;
    }
}
