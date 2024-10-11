namespace Expense_Tracker.Services;

public class ExpenseManager
{
    private readonly List<Expense> _expenses = [];
    private readonly static Lazy<ExpenseManager> _instance
        = new(() => new ExpenseManager());

    public static ExpenseManager Instance { get => _instance.Value; }

    private ExpenseManager()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of TaskManagerService");
    }

    public void LoadAllExpenses(List<Expense> _expenses)
    {
        this._expenses.Clear();
        this._expenses.AddRange(_expenses);
    }

    public Expense CreateExpense(string description, double amount)
    {
        var maxId = _expenses.Count > 0 ? _expenses.Last().Id : 0;
        _expenses.Add(new Expense()
        {
            Id = maxId + 1,
            Description = description,
            Amount = amount,
            Date = DateTime.Now
        });

        return _expenses.Last();
    }

    public void SaveAll() => StoreService.Instance.Write(_expenses);

    public Expense GetExpense(int id)
    {
        return _expenses.FirstOrDefault(t => t.Id == id);
    }

    public List<Expense> GetExpenses(params int[] expenseIds)
    {
        return _expenses.FindAll(t => expenseIds.Contains(t.Id));
    }

    public List<Expense> GetAll() => _expenses;

    public bool DeleteExpense(int expenseId)
    {
        var expense = GetExpense(expenseId);
        if (expense != null)
            _expenses.Remove(expense);
        return expense != null;
    }

    public double Summary() => _expenses.Sum(e => e.Amount);
}
