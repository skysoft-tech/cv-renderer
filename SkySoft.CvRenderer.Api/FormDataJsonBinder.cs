using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SkySoft.CvRenderer.Utils.Deserialization;

namespace SkySoft.CvRenderer.Api
{
    public class FormDataJsonBinder : IModelBinder
    {
        private readonly Deserializer _deserializer;

        public FormDataJsonBinder(Deserializer deserializer)
        {
            _deserializer = deserializer;
        }
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var fieldName = bindingContext.FieldName;
            var valueProviderResult = bindingContext.ValueProvider.GetValue(fieldName);

            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }
            else
            {
                bindingContext.ModelState.SetModelValue(fieldName, valueProviderResult);
            }

            var value = valueProviderResult.FirstValue;

            if (string.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }

            try
            {
                var result = _deserializer.DeserializeJson(value, bindingContext.ModelType);
                bindingContext.Result = ModelBindingResult.Success(result);
            }
            catch (JsonException)
            {
                bindingContext.Result = ModelBindingResult.Failed();
            }

            return Task.CompletedTask;
        }
    }
}
