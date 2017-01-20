namespace ArmyOfCreatures.Extended
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

        public static void CheckIfIntegerIsInRange(int value, int max, int min = 0, string message = null)
        {
            if (value < min || max < value)
            {
                throw new IndexOutOfRangeException(message);
            }
        }
    }
}
