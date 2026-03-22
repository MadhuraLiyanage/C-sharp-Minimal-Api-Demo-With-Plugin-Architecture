using System.Reflection;
using Plugin.Abstractions;

namespace Plugin.Framework;

public static class PluginLoader
{
    public static List<IApiPlugin> Load(string folder)
    {
        var plugins = new List<IApiPlugin>();

        if (!Directory.Exists(folder))
            return plugins;

        foreach (var dll in Directory.GetFiles(folder, "*.dll"))
        {
            var assembly = Assembly.LoadFrom(dll);

            var types = assembly.GetTypes()
                .Where(t => typeof(IApiPlugin).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in types)
            {
                if (Activator.CreateInstance(type) is IApiPlugin plugin)
                {
                    plugins.Add(plugin);
                }
            }
        }

        return plugins;
    }
}