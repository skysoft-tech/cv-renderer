using Newtonsoft.Json;
using System.Reflection;

namespace SkySoft.CvRenderer.Utils.JsonHelpers
{
    internal class NullFilteringListConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            if (objectType.IsArray || objectType == typeof(string) || objectType.IsPrimitive)
            {
                return false;
            }
                
            var itemType = objectType.GetListItemType();

            return itemType != null && (!itemType.IsValueType || Nullable.GetUnderlyingType(itemType) is not null);
        }

        object? ReadJsonGeneric<T>(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var list = existingValue as List<T> ?? serializer.ContractResolver.ResolveContract(objectType).DefaultCreator() as List<T>;

            if (list != null) 
            {
                serializer.Populate(reader, list);

                list.RemoveAll(i => i == null);
            }

            return list;
        }

        public override object? ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var itemType = objectType.GetListItemType();
            var method = typeof(NullFilteringListConverter).GetMethod(
                "ReadJsonGeneric", BindingFlags.NonPublic 
                | BindingFlags.Instance 
                | BindingFlags.Public
            );

            try
            {
                return method!.MakeGenericMethod([itemType!]).Invoke(this, [reader, objectType, existingValue, serializer]);
            }
            catch (Exception ex)
            {
                throw new JsonSerializationException("Failed to deserialize " + objectType, ex);
            }
        }

        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }

    public static partial class JsonExtensions
    {
        internal static Type? GetListItemType(this Type type)
        {
            if (type.IsPrimitive || type.IsArray || type == typeof(string))
            {
                return null;
            }

            while(type is not null)
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
