using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    // source: https://stackoverflow.com/a/62941295/2473732
    internal class NullFilteringListConverter : JsonConverter
    {
        private static readonly MethodInfo? _readJsonGeneric = typeof(NullFilteringListConverter).GetPrivateMethod(nameof(ReadJsonGeneric));

        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsArray || objectType == typeof(string) || objectType.IsPrimitive)
            {
                return false;
            }
                
            var itemType = objectType.GetListItemType();
            if (itemType == null)
            {
                return false;
            }

            var isNullableValueTypeWithoutValue = itemType.IsValueType && Nullable.GetUnderlyingType(itemType) == null;
            if (isNullableValueTypeWithoutValue)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// NOTE: this method used in reflection in method <see cref="ReadJson(JsonReader, Type, object?, JsonSerializer)"/>
        /// </summary>
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Cannot be static due to way how it used in reflection")]
        [SuppressMessage("Performance", "CA1859:Use concrete types when possible for improved performance", Justification = "")]
        object? ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = existingValue as List<T>;
            if (list == null)
            {
                var contract = serializer.ContractResolver.ResolveContract(objectType);
                var objectFactory = contract.DefaultCreator;
                list = objectFactory?.Invoke() as List<T>;
            }

            if (list != null) 
            {
                serializer.Populate(reader, list);

                list.RemoveAll(i => i == null);
            }

            return list;
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            var itemType = objectType.GetListItemType();

            try
            {
                return _readJsonGeneric!.MakeGenericMethod([itemType!]).Invoke(this, [reader, objectType, existingValue, serializer]);
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("Failed to deserialize " + objectType, ex);
            }
        }

        public override bool CanWrite => false;

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer) => throw new NotImplementedException();
    }

    internal static class ReflectionHelpers
    {
        internal static MethodInfo? GetPrivateMethod(this Type? type, string methodName)
        {
            var allInstanceMethods = BindingFlags.NonPublic | BindingFlags.Instance;

            return type?.GetMethod(methodName, allInstanceMethods);
        }

        internal static Type? GetListItemType(this Type? type)
        {
            if (type == null || type.IsPrimitive || type.IsArray || type == typeof(string))
            {
                return null;
            }

            while (type != null)
            {
                if (type.IsGenericType)
                {
                    if (type.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        return type.GetGenericArguments()[0];
                    }
                        
                }

                type = type.BaseType;
            }

            return null;
        }
    }
}
