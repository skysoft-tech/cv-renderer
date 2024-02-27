using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SkySoft.CvRenderer.Cli.CliOptions
{
    public static class OptionsDataExtensions
    {
        public static void SetOptionByKey<T>(
            this IDictionary<string, string> data,
            Expression<OptionsPropertyAccessor<T>> keyAccessor,
            T value
        )
        {
            var key = OptionKeySelector.GetKey(keyAccessor);

            switch (value)
            {
                case string strValue:
                    AddValueToSettingsDictionary(data, key, strValue);
                    break;
                case IEnumerable enumerableValue:
                    AddValueToSettingsDictionary(data, key, enumerableValue);
                    break;
                default:
                    AddValueToSettingsDictionary(data, key, value?.ToString());
                    break;
            }
        }

        private static void AddValueToSettingsDictionary(
            IDictionary<string, string> data,
            string key,
            IEnumerable value
        )
        {
            if (value == null)
            {
                return;
            }

            var index = 0;
            foreach (var item in value)
            {
                data[$"{key}:{index}"] = item.ToString();

                index++;
            }
        }

        private static void AddValueToSettingsDictionary(IDictionary<string, string> data, string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            data[key] = value;
        }
    }
}
