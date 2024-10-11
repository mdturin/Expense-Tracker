using Expense_Tracker.Interfaces;
using Expense_Tracker.Services;
using System.CommandLine;
using System.Globalization;

namespace Expense_Tracker.Commands;

public class SummaryCommand : IArgsCommand
{
    public Command Execute()
    {
        var monthOption = new Option<int?>("--month", "Month number") { IsRequired = false };
        var summaryCommand = new Command("summary", "Total expenses")
        {
            monthOption
        };

        summaryCommand.SetHandler((int? monthNumber) =>
        {
            if (monthNumber.HasValue)
            {
                var totalAmount = ExpenseManager.Instance.Summary(monthNumber.Value);
                var monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber.Value);
                Console.WriteLine($"Total expenses for {monthName}: {totalAmount}");
            }
            else
            {
                var totalAmount = ExpenseManager.Instance.Summary();
                Console.WriteLine($"Total expenses: {totalAmount}");
            }
        }, monthOption);

        return summaryCommand;
    }
}
