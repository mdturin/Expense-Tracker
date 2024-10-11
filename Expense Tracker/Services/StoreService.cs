using System.Text.Json;

namespace Expense_Tracker.Services;

public class StoreService
{
    private readonly string _filePath;
    private readonly string _storePath;
    private readonly static Lazy<StoreService> _instance
        = new(() => new StoreService());

    public static StoreService Instance { get => _instance.Value; }

    private StoreService()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of StoreService");

        var instance = ConfigurationService.Instance;
        _storePath = instance.GetConfig("StorePath");
        if (string.IsNullOrWhiteSpace(_storePath))
            _storePath = Path.GetTempPath();

        var fileName = instance.GetConfig("FileName");
        if (string.IsNullOrWhiteSpace(fileName))
            fileName = "TaskStore";

        _filePath = Path.Join(_storePath, fileName);
        _filePath = Path.ChangeExtension(_filePath, "json");
    }

    public List<Expense> ReadAll()
    {
        if (!Directory.Exists(_storePath))
        {
            Directory.CreateDirectory(_storePath);
        }

        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, JsonSerializer.Serialize(new List<Expense>()));
            return [];
        }

        var jsonStr = File.ReadAllText(_filePath);
        var expenses = JsonSerializer.Deserialize<List<Expense>>(jsonStr, new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = true
        });

        return expenses;
    }

    public void Write(List<Expense> expenses)
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(expenses, options);
        File.WriteAllText(_filePath, jsonString);
    }
}