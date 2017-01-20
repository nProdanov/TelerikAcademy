using System;
using System.Collections.Generic;

namespace InheritanceAndPolymorphism.Utils
{
    public static class Validator
    {
        public static void ValidateIfValidString(string text, string parameterName = "Value")
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException(string.Format("{0} must not be a null or empty string", parameterName));
            }
        }

        public static void ValidateIfValidCollection(ICollection<string> collection, string parameterName = "Value")
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException(string.Format("{0} must not be a null or empty collection", parameterName));
            }
        }
    }
}
