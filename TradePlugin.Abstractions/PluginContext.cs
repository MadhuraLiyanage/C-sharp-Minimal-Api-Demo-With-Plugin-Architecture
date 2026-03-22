using Microsoft.AspNetCore.Http;

namespace Plugin.Abstractions;

public class PluginContext
{
    public required HttpContext HttpContext { get; set; }
    public required object Request { get; set; }
    public required IServiceProvider Services { get; set; }
    public required string PluginId { get; set; }
    public Dictionary<string, object> Items { get; } = new();
}