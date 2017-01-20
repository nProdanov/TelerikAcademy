using System;
using System.Text;

namespace DbFirst.DataImporter.RandomGenerator
{
    public class RandomGenerator : IRandomGenerator
    {
        private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        private readonly Random random = new Random();

        public int GetRandomNumber(int min = 0, int max = int.MaxValue / 2)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int minLenght = 0, int maxLength = int.MaxValue / 2)
        {
            var length = random.Next(minLenght, maxLength);

            var result = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                var randomAlphabetIndex = random.Next(0, Alphabet.Length);
                result.Append(Alphabet[randomAlphabetIndex]);
            }

            return result.ToString();
        }

        public DateTime GetRandomDate(DateTime? after = null, DateTime? before = null)
        {
            var minDate = after ?? new DateTime(2010, 01, 01, 0, 0, 0);
            var maxDate = before ?? new DateTime(2020, 12, 31, 23, 59, 59);

            var seconds = GetRandomNumber(minDate.Second, maxDate.Second);
            var minutes = GetRandomNumber(minDate.Minute, maxDate.Minute);
            var hours = GetRandomNumber(minDate.Hour, maxDate.Hour);

            var day = GetRandomNumber(minDate.Day, maxDate.Day);
            var month = GetRandomNumber(minDate.Month, maxDate.Month);
            var year = GetRandomNumber(minDate.Year, maxDate.Year);

            if (day > 28)
            {
                day = 28;
            }

            return new DateTime(year, month, day, hours, minutes, seconds);
        }
    }
}
