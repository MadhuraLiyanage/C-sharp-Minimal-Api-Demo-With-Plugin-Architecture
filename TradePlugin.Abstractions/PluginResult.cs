namespace Plugin.Abstractions;

public class PluginResult
{
    public bool Continue { get; set; } = true;
    public string? Message { get; set; }
    public object? Data { get; set; }
}