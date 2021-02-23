using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace TagSDK.Utils
{
    public class CustomQueryParams
    {
        public string ReturnQueryParams(params object[] objts)
        {
            return ReturnQueryParams(string.Empty, objts);
        }

        public string ReturnQueryParams(string queryString, params object[] objts)
        {
            foreach (var obj in objts)
            {
                var typeObj = obj.GetType();
                IList<PropertyInfo> props = new List<PropertyInfo>(typeObj.GetProperties());

                foreach (var prop in props)
                {
                    var value = prop.GetValue(obj, null);

                    if (value != null)
                    {
                        var propName = prop.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName;
                        if (propName != null)
                        {
                            if (typeof(DateTime).IsInstanceOfType(value))
                            {
                                value = ConvertDate((DateTime)value);
                            }

                            queryString = string.IsNullOrEmpty(queryString) ? $"?{propName}={value}" : $"{queryString}&{propName}={value}";
                        }
                    }
                }

            }

            return queryString;
        }

        public string ConvertDate(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }
    }
}
