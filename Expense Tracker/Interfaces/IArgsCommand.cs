using System.CommandLine;

namespace Expense_Tracker.Interfaces;

public interface IArgsCommand
{
    Command Execute();
}
