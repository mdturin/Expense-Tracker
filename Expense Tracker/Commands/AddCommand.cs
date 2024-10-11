using Expense_Tracker.Interfaces;
using System.CommandLine;

namespace Expense_Tracker.Commands;

public class AddCommand : IArgsCommand
{
    public Command Execute()
    {
        // Define the options for the add command
        var descriptionOption = new Option<string>("--description", "Description of the expense") { IsRequired = true };
        var amountOption = new Option<decimal>("--amount", "Amount of the expense") { IsRequired = true };

        // Command to add an expense
        var addCommand = new Command("add", "Add a new expense")
        {
            descriptionOption,
            amountOption
        };

        addCommand.SetHandler((string description, decimal amount) =>
        {
            var expense = new Expense
            {
                Description = description,
                Amount = amount,
                Date = DateTime.Now
            };

            Console.WriteLine($"Added expense: {expense}");
        }, descriptionOption, amountOption);

        return addCommand;
    }
}
