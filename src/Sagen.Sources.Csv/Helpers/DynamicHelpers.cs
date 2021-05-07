using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Sagen.Sources.Csv.Helpers
{
    public static class DynamicHelpers
    {
        public static T GetPropertyValueAs<T>(dynamic item, string propertyName)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new ArgumentException(
                    $"{nameof(propertyName)} cannot be null or whitespace.", 
                    nameof(propertyName));
            }

            object retval;
            if (item is ExpandoObject eo)
            {
                if (!(eo as IDictionary<string, object>).TryGetValue(propertyName, out retval))
                {
                    throw new ArgumentException(
                        $"A property with name '{propertyName}' does not exist.",
                        nameof(propertyName));
                }
            }
            else
            {
                var t = item.GetType();
                var property = t.GetProperty(propertyName);

                if (property == null)
                {
                    throw new ArgumentException(
                        $"A property with name '{propertyName}' does not exist.",
                        nameof(propertyName));
                }
                else
                {
                    retval = property.GetValue(item);
                }
            }

            return (T)retval;
        }
    }
}
