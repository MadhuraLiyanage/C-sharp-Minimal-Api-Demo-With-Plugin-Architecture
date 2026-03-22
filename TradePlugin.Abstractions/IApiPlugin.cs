namespace Plugin.Abstractions;

public interface IApiPlugin
{
    string Name { get; }
    PluginStage Stage { get; }
    int Order { get; }
    Task<PluginResult> ExecuteAsync(PluginContext context);
}