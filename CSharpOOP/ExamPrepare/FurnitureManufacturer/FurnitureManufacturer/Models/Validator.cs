namespace FurnitureManufacturer.Models
{
    using System;

    public static class Validator
    {
        public static void CheckIfNull(object obj, string message = null)
        {
            if (obj == null)
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfStringIsNullOrEmpty(string text, string message = null)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new NullReferenceException(message);
            }
        }

        public static void CheckIfMinStringLengthIsValid(string text, int min, string message = null)
        {
            if (text.Length < min)
            {
                throw new IndexOutOfRangeException(message);
            }
        }

        public static void CheckForPositiveDecimal(decimal number, string prop = null, string meassure = null)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("This {0} can not be less or equal to 0{1}!", prop, meassure));
            }
        }
    }
}
