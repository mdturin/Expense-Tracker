using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class UpdateCommand : IArgsCommand
{
    public Command Execute()
    {
        // Define the options for the add command
        var idOption = new Option<int>(["--id", "id"], "Expense Id") { IsRequired = true };
        var descriptionOption = new Option<string>("--description", "Description of the expense") { IsRequired = true };
        var amountOption = new Option<double>("--amount", "Amount of the expense") { IsRequired = true };

        // Command to add an expense
        var updateCommand = new Command("update", "Update an expense")
        {
            idOption,
            descriptionOption,
            amountOption
        };

        updateCommand.SetHandler((int id, string description, double amount) =>
        {
            if (ExpenseManager.Instance.UpdateExpense(id, description, amount))
            {
                ExpenseManager.Instance.SaveAll();
                Console.WriteLine($"Expense updated successfully (ID: {id})");
            }
            else
            {
                Console.WriteLine($"Expense update failed!");
            }
        }, idOption, descriptionOption, amountOption);

        return updateCommand;
    }
}
