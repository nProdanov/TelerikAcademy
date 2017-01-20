using System;

namespace Abstraction.Utils
{
    public static class Validator
    {
        public static void ValidateFigurePart(double figurePart, string partName = "The part of figure")
        {
            if (figurePart <= 0)
            {
                throw new ArgumentOutOfRangeException(partName, " must be a positive number");
            }
        }
    }
}
