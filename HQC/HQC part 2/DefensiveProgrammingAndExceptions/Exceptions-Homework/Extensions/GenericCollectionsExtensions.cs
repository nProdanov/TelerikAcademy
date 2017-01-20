using System;
using System.Collections.Generic;

using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Extensions
{
    public static class GenericCollectionsExtensions
    {
        public static T[] Subsequence<T>(this T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array must not be empty");
            }

            Validator.ValidateIfNonNegativeNumber(startIndex, "Start index");

            if (arr.Length <= startIndex)
            {
                throw new ArgumentException(string.Format("Start index must be between 0 and {0}", arr.Length - 1));
            }

            Validator.ValidateIfNonNegativeNumber(count, "Count of Subsequence");

            if (arr.Length < startIndex + count)
            {
                throw new ArgumentException("Count of Subsequence is too long");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }
    }
}
