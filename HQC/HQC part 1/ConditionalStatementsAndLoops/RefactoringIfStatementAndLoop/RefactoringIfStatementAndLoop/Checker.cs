namespace RefactoringIfStatementAndLoop
{
    using System;

    public static class Checker
    {
        public static bool IsPotatoReadyForCook(Potato potato)
        {
            if (potato != null)
            {
                if (potato.IsPeeled && potato.IsNotRotten)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException("potato");
            }
        }

        public static bool IsInRange(int value, int minValue, int maxValue)
        {
            if (minValue <= value && value <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool ShouldVisitCell(
            int x,
            int minX,
            int maxX,
            int y,
            int minY,
            int maxY,
            bool cellIsVisited)
        {
            bool isXInRange = IsInRange(x, minX, maxX);
            bool isYInRange = IsInRange(y, minY, maxY);

            if (isXInRange && isYInRange && !cellIsVisited)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsArrayContainsValueOnIndexDevisibleByTen(int[] numbers, int searchNumber)
        {
            bool found = false;

            for (int i = 0; i < numbers.Length; i += 10)
            {
                if (numbers[i] == searchNumber)
                {
                    found = true;
                    break;
                }
            }

            return found;
        }
    }
}
