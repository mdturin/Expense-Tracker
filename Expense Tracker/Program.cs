using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;
using System.Reflection;

var rootCommand = new RootCommand("Expense Tracker CLI");
LoadAllCommands(rootCommand);

rootCommand.TreatUnmatchedTokensAsErrors = true;
await rootCommand.InvokeAsync(args);

static void LoadAllCommands(Command rootCommand)
{
    Assembly
        .GetExecutingAssembly()
        .GetTypes()
        .Where(t => typeof(IArgsCommand).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
        .ToList()
        .ForEach(type =>
        {
            var instance = (IArgsCommand)Activator.CreateInstance(type);
            var command = instance?.Execute();
            if (command != null)
                rootCommand.Add(command);
        });

    var expenses = StoreService.Instance.ReadAll();
    ExpenseManager.Instance.LoadAllExpenses(expenses);
}
