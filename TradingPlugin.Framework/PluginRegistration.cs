namespace Plugin.Framework;

public class PluginRegistration
{
    public string PluginId { get; set; } = string.Empty;
    public string PluginName { get; set; } = string.Empty;
    public bool Enabled { get; set; }
}