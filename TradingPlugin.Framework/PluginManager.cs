using Microsoft.Extensions.Configuration;
using Plugin.Abstractions;

namespace Plugin.Framework;

public class PluginManager
{
    private readonly List<IApiPlugin> _plugins;
    private readonly List<PluginRegistration> _registrations;

    public PluginManager(IConfiguration configuration)
    {
        var pluginPath = Path.Combine(AppContext.BaseDirectory, "plugins");

        _plugins = PluginLoader.Load(pluginPath);

        _registrations =
            configuration.GetSection("PluginRegistrations")
            .Get<List<PluginRegistration>>() ?? new();
    }

    public async Task<PluginResult> ExecuteAsync(
        PluginStage stage,
        PluginContext context)
    {
        var allowed = _registrations
            .Where(x => x.PluginId == context.PluginId && x.Enabled)
            .Select(x => x.PluginName)
            .ToHashSet();

        var plugins = _plugins
            .Where(p => p.Stage == stage && allowed.Contains(p.Name))
            .OrderBy(p => p.Order);

        foreach (var plugin in plugins)
        {
            var result = await plugin.ExecuteAsync(context);

            if (!result.Continue)
                return result;
        }

        return new PluginResult();
    }
}