using System.Collections.Generic;

namespace MyMortgage.Common.Validation
{
    public static class Value
    {
        public static bool IsNull<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }

        public static bool IsNotNull<T>(T value)
        {
            return !IsNull(value);
        }

        public static bool StringIsEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool StringIsNotEmpty(string value)
        {
            return !StringIsEmpty(value);
        }
    }
}
