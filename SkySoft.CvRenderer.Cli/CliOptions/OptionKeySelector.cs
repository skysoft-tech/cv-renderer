using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    internal class OptionKeySelector
    {
        private static ConcurrentDictionary<Type, PropertyInfo[]> _propertiesByType = new();

        public static string GetKey(LambdaExpression propertyAccessor)
        {
            var propertyInfo = GetKeyProperty(propertyAccessor);

            var configurationKey = propertyInfo.GetCustomAttribute<OptionKeyNameAttribute>();
            if (configurationKey == null)
            {
                throw new ArgumentException(
                    $"Expression '{propertyAccessor}' refers to property without OptionsKeyNameAttribute"
                );
            }

            return configurationKey.Name;
        }

        public static string[] GetAliases(LambdaExpression propertyAccessor)
        {
            var propertyInfo = GetKeyProperty(propertyAccessor);

            var configurationKey = propertyInfo.GetCustomAttributes<CliOptionNameAttribute>();
            if (configurationKey == null)
            {
                throw new ArgumentException(
                    $"Expression '{propertyAccessor}' refers to property without OptionsKeyNameAttribute"
                );
            }

            var aliases = configurationKey.SelectMany(s => s.Aliases);

            return aliases.ToArray();
        }

        public static string GetDescription(LambdaExpression propertyAccessor)
        {
            var propertyInfo = GetKeyProperty(propertyAccessor);

            var configurationKey = propertyInfo.GetCustomAttributes<CliOptionDescriptionAttribute>();
            if (configurationKey == null)
            {
                throw new ArgumentException(
                    $"Expression '{propertyAccessor}' refers to property without OptionsKeyNameAttribute"
                );
            }

            return configurationKey.Select(s => s.Description).FirstOrDefault() ?? "";
        }

        public static PropertyInfo[] GetOptionsProperties<T>()
        {
            var targetType = typeof(T);

            return _propertiesByType.GetOrAdd(targetType, (t) => GetOptionsProperties(t).ToArray());
        }

        private static IEnumerable<PropertyInfo> GetOptionsProperties(Type type, HashSet<Type> visited = null)
        {
            // to avoid endless recursion
            visited = visited ?? new HashSet<Type>();
            if (!visited.Add(type))
                yield break;

            foreach (var property in type.GetProperties())
            {
                if (property.GetCustomAttributes<OptionKeyNameAttribute>().Any())
                    yield return property;

                // recursion for child properties
                foreach (var result in GetOptionsProperties(property.PropertyType, visited))
                    yield return result;
            }
        }

        private static PropertyInfo GetKeyProperty(LambdaExpression propertyAccessor)
        {
            if (propertyAccessor.Body is not MemberExpression memberExpression)
            {
                throw new ArgumentException($"Expression '{propertyAccessor}' refers to a function, not a property.");
            }

            if (memberExpression.Member is not PropertyInfo propertyInfo)
            {
                throw new ArgumentException($"Expression '{propertyAccessor}' refers to a field, not a property.");
            }

            return propertyInfo;
        }
    }
}
