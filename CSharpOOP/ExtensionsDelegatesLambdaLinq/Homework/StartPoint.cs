namespace Homework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Extensions;
    using Students;

    public class StartPoint
    {
        public static void Separator()
        {
            Console.WriteLine(new string('-', 25));
        }

        public static void Main()
        {
            // Test Task 1
            Console.WriteLine("Substring of Stringbuilder: ");
            var strBuild = new StringBuilder();
            strBuild.Append("Lorem ipsum dolor sit amet, consectetur adipiscing elit.");
            var newStrBuild = strBuild.Substring(0, 7);
            Console.WriteLine(newStrBuild.ToString());
            Separator();

            // Test Task 2
            var list = new List<int>();

            for (int i = 1; i <= 35; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine("The sum of elements in collection is: {0}", list.Sum());
            Console.WriteLine("The product of elements in collection is: {0}", list.Product());
            Console.WriteLine("Minimal value of all elements is: {0}", list.Min());
            Console.WriteLine("Maximal value of all elements is: {0}", list.Max());
            Console.WriteLine("Average value of elements is: {0}", list.Average());
            Separator();

            // Creating list of students
            var studentsList = TestStudents.GenerateListStudents();

            // Adding some marks
            studentsList[0].AddMark(Course.CSharpFundamentals, MarkValue.Excellent);
            studentsList[0].AddMark(Course.CSharpAdvanced, MarkValue.VeryGood);
            studentsList[0].AddMark(Course.HTMLFundamentals, MarkValue.Excellent);
            studentsList[0].AddMark(Course.CSS, MarkValue.Fair);

            studentsList[1].AddMark(Course.CSharpOOP, MarkValue.Poor);
            studentsList[1].AddMark(Course.JavaScript, MarkValue.Good);

            studentsList[2].AddMark(Course.CSharpOOP, MarkValue.Good);
            studentsList[2].AddMark(Course.JavaScript, MarkValue.Good);
            studentsList[2].AddMark(Course.CSS, MarkValue.VeryGood);
            studentsList[2].AddMark(Course.CSharpFundamentals, MarkValue.Good);

            studentsList[3].AddMark(Course.CSharpOOP, MarkValue.Excellent);
            studentsList[3].AddMark(Course.JavaScript, MarkValue.Excellent);
            studentsList[3].AddMark(Course.CSS, MarkValue.VeryGood);
            studentsList[3].AddMark(Course.CSharpFundamentals, MarkValue.Excellent);

            studentsList[4].AddMark(Course.CSharpOOP, MarkValue.Poor);
            studentsList[4].AddMark(Course.JavaScript, MarkValue.Good);
            studentsList[4].AddMark(Course.CSS, MarkValue.VeryGood);
            studentsList[4].AddMark(Course.CSharpFundamentals, MarkValue.Good);

            studentsList[5].AddMark(Course.CSharpOOP, MarkValue.Poor);
            studentsList[5].AddMark(Course.JavaScript, MarkValue.Good);
            studentsList[5].AddMark(Course.CSS, MarkValue.VeryGood);
            studentsList[5].AddMark(Course.CSharpFundamentals, MarkValue.Good);

            studentsList[6].AddMark(Course.CSharpOOP, MarkValue.VeryGood);
            studentsList[6].AddMark(Course.JavaScript, MarkValue.Good);
            studentsList[6].AddMark(Course.CSS, MarkValue.Poor);
            studentsList[6].AddMark(Course.CSharpFundamentals, MarkValue.Fair);

            // Adding some phoneNumbers
            studentsList[0].PhoneNumber = "+359882888777";
            studentsList[1].PhoneNumber = "+359884777888";
            studentsList[2].PhoneNumber = "+359885222333";
            studentsList[3].PhoneNumber = "+359882111222";
            studentsList[4].PhoneNumber = "+359882555666";
            studentsList[5].PhoneNumber = "+359883123456";
            studentsList[6].PhoneNumber = "+359882987654";

            Console.WriteLine("List of students: ");
            studentsList.PrintCollection();
            Separator();

            // Task 3
            Console.WriteLine("Students with first name before last: ");
            var studentsWithFirstNameBeforeLast = TestStudents.FilterByFirstNameBeforeLast(studentsList);
            studentsWithFirstNameBeforeLast.PrintCollection();
            Separator();

            // Task 4
            Console.WriteLine("First and last name of studnets between 18 and 24: ");
            var filteredStudentsByAge = TestStudents.FilterByAge(studentsList);
            filteredStudentsByAge.PrintCollection();
            Separator();

            // Task 5
            Console.WriteLine("Descending ordered list of students by names : ");

            // with Query
            var orderedDescList = TestStudents.OrderByDescendingQuery(studentsList);

            // with extension methods
            // var orderedDescList = studentsList.OrderByDescendingExt();
            orderedDescList.PrintCollection();
            Separator();

            // Task 6
            Console.WriteLine("Extension Methods: ");
            var devisibleExt =
                list
                .Where(number => number % 21 == 0);
            devisibleExt.PrintCollection();
            Separator();

            Console.WriteLine("Query: ");
            var devisibleQuery = from num in list
                                 where num % 21 == 0
                                 select num;
            devisibleQuery.PrintCollection();
            Separator();

            // Task 7 
            var timer = new Timer(2, 3);
            timer.Methods += FirstMethod;
            timer.Methods += SecondMethod;
            timer.Run();
            Separator();

            // Task 8 - TO DO 
            var timerWithEvent = new TimerEvent(1, 2);
            timerWithEvent.Methods += FirstMethod;
            timerWithEvent.Run();
            Separator();

            // Task 9 
            Console.WriteLine("Students from goup number 2");
            var secondGrStuds = TestStudents.GroupStudsByGroup(studentsList, GroupNumber.second);
            secondGrStuds.PrintCollection();
            Separator();

            // Task 10
            Console.WriteLine("Students from number 3");
            var thirdGrStuds = TestStudents.GroupStudsByGroupMethods(studentsList, GroupNumber.third);
            thirdGrStuds.PrintCollection();
            Separator();

            // Task 11
            Console.WriteLine("Students with emails by \"abv.bg\" domain:");
            var studsAbvBg = TestStudents.ExtractSudsByMail(studentsList, "abv.bg");
            studsAbvBg.PrintCollection();
            Separator();

            // Task 12
            Console.WriteLine("Students with phones from Sofia:");
            var studsFromSofia = TestStudents.ExtractStudsByPhone(studentsList);
            studentsList.PrintCollection();
            Separator();

            // Task 13 - TODO
            Console.WriteLine("Extracted Students with mark 6:");
            TestStudents.ExtractStudsByMarkSix(studentsList);
            Separator();

            // Task 14
            Console.WriteLine("Extracted Students with exactly 2 marks:");
            TestStudents.ExtractStudsByMakrsCount(studentsList, 2);
            Separator();

            // Task 15
            Console.WriteLine("Marks of Students enrolled in 2006:");
            TestStudents.ExtractStudsByYear(studentsList, "06");
            Separator();

            // Task 16
            Console.WriteLine("Students from Math Department: ");
            var mathDeptStuds = TestStudents.ExtractStudsByDepartment(studentsList, "Math");
            mathDeptStuds.PrintCollection();
            Separator();

            // Task 17
            var strArr = new string[]
            {
                "I am the coolest string",
                "I am the strongest string",
                "I am the looooooongest string"
            };
            var longestStr = (from str in strArr
                              orderby str.Length descending
                              select str).First();
            Console.WriteLine(longestStr);
            Separator();

            // Task 18
            Console.WriteLine("Students grouped by group number:");
            TestStudents.PrintStudsByGroup(studentsList);
            Separator();

            // Task 19
            Console.WriteLine("Students grouped by department:");
            TestStudents.PrintStudsByDepartment(studentsList);
            Separator();

            // Task 20 - TODO
        }

        public static void FirstMethod()
        {
            Console.WriteLine("This is first Method");
            Console.WriteLine();
        }

        public static void SecondMethod()
        {
            Console.WriteLine("This is second method");
            Console.WriteLine();
        }
    }
}
