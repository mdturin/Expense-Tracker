namespace Expense_Tracker;

public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }
    public DateTime Date { get; set; }

    public override string ToString() => $"{Id}\t{Date.ToShortDateString()}\t{Description}\t\t{Amount}";
}