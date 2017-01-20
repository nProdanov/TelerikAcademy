using System;

    class Program
    {
        static void Main()
        {
            DateTime bday = DateTime.Parse(Console.ReadLine());
            DateTime today = DateTime.Now;
            int age = 0;
            int ageAfter = 0;
            if (today.Month>=bday.Month && today.Year>=bday.Year)
            {
                if (today.Day >= bday.Day)
                {
                    age = today.Year - bday.Year;
                    ageAfter = age + 10;
                }
                else
                {
                    age = today.Year - bday.Year - 1;
                    ageAfter = age + 10;
                }
            }
            else if (today.Month < bday.Month && today.Year >= bday.Year)
            {
                age = today.Year - bday.Year -1;
                ageAfter = age + 10;
            }
            else
            {
                ageAfter = 9;
            }
            Console.WriteLine(age);
            Console.WriteLine(ageAfter);
        }
    }

