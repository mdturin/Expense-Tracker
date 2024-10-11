using System.Text.Json;

namespace Expense_Tracker.Services;

public class ConfigurationService
{
    private Dictionary<string, string> _values = [];
    private readonly static Lazy<ConfigurationService> _instance
        = new(() => new ConfigurationService());

    public static ConfigurationService Instance { get => _instance.Value; }

    private ConfigurationService()
    {
        if (_instance.IsValueCreated)
            throw new Exception("Duplication of ConfigurationService");

        LoadAppConfig();
    }

    private void LoadAppConfig()
    {
        if (!File.Exists("C:\\AppStore\\appconfig.json"))
        {
            return;
        }

        var jsonString = File.ReadAllText("C:\\AppStore\\appconfig.json");
        _values = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonString, new JsonSerializerOptions()
        {
            AllowTrailingCommas = true,
        });
    }

    public bool Contains(string key) => _values.ContainsKey(key);

    public string GetConfig(string key)
    {
        if (!Contains(key))
            return null;

        return _values[key];
    }
}
