using System.Reflection;
using System.Text.Json.Serialization;

namespace Trading.BaseModels
{
    public class ModelBase
    {
        // To Identify the source of the data
        public string PluginId = string.Empty;

        // Returns true if any public instance string property is null or empty
        public bool AnyStringPropertyNullOrEmpty()
        {
            foreach (var prop in GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
            {
                if (prop.PropertyType == typeof(string))
                {
                    var value = (string?)prop.GetValue(this);
                    if (string.IsNullOrEmpty(value))
                        return true;
                }
            }

            return false;
        }

        // Check a specific public instance property by name. Returns true if the property exists, is a string, and is null or empty.
        public bool IsPropertyNullOrEmpty(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return true;

            var prop = GetType().GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null || prop.PropertyType != typeof(string))
                return false;

            var value = (string?)prop.GetValue(this);
            return string.IsNullOrEmpty(value);
        }

    }
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? value) => string.IsNullOrEmpty(value);
    }
}
