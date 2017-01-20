namespace StudentClient
{
    using System;
    using Student;
    using Student.Enumerations;

    public class StudentTestClient
    {
        public static void Main()
        {
            var firstStud = new Student(
                "Dragan", 
                "Ivanov", 
                "Georgiev", 
                "120120120", 
                "Sofia, Mladost, Al. Malinov 34", 
                "0888333222111", 
                "drago.chaya@abv.bg", 
                2, 
                University.UNWE, 
                Faculty.FinancesAndAccountary, 
                Specialty.Law);

            var clonedStud = (Student)firstStud.Clone();
            clonedStud.FirstName = "Aladin";
            clonedStud.Email = new System.Net.Mail.MailAddress("aladin@yagoo.com");
            
            Console.WriteLine(firstStud);

            Console.WriteLine(clonedStud);

            Console.WriteLine(string.Format("First Student equals to the changed clone?  ->  {0} ", firstStud == clonedStud));

            // Compare 
            var compareResult = string.Empty;
            if (firstStud.CompareTo(clonedStud) < 0)
            {
                compareResult = " is before ";
            }
            else if (firstStud.CompareTo(clonedStud) > 0)
            {
                compareResult = " is after ";
            }
            else
            {
                compareResult = " is on same position as ";
            }

            Console.WriteLine();
            Console.WriteLine(string.Format("First studend{0}changed clone", compareResult));
        }
    }
}
