
// Expense class to store expense data
public class Expense
{
    public int Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public override string ToString() => $"ID: {Id}, Description: {Description}, Amount: {Amount}, Date: {Date.ToShortDateString()}";
}