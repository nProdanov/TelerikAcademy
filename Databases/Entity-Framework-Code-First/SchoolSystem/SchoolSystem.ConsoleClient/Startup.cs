using System;
using System.Data.Entity;
using System.Linq;

using SchoolSystem.Data;
using SchoolSystem.Data.Migrations;
using SchoolSystem.Models;

namespace SchoolSystem.ConsoleClient
{
    public class Startup
    {
        public const string TaskSeparator = "---------------------";

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolDbContext, Configuration>());

            using (var schoolDb = new SchoolDbContext())
            {
                AddHtmlHw(schoolDb);
                Console.WriteLine(TaskSeparator);

                PrintAllHtmlHomeworks(schoolDb);
                Console.WriteLine(TaskSeparator);

                PrintAllJsHomeworksOfIvan(schoolDb);
                Console.WriteLine(TaskSeparator);

                SeedJsCourse(schoolDb);
                Console.WriteLine(TaskSeparator);

                PrintAllJsStudents(schoolDb);
                Console.WriteLine(TaskSeparator);
            }
        }

        public static void PrintAllJsStudents(SchoolDbContext schoolDb)
        {
            var studentsJs = schoolDb
                                  .Students
                                  .Where(st => st
                                                .Courses
                                                .Any(c => c.Name == "javascript"))
                                  .ToList();

            Console.WriteLine("Students of JS course:");
            foreach (var stud in studentsJs)
            {
                Console.WriteLine(stud.Name);
            }
        }

        public static void SeedJsCourse(SchoolDbContext schoolDb)
        {
            var mimi = new Student() { Name = "Maria", Age = 15, SSN = "9876543" };
            var tisho = new Student() { Name = "Tihomir", Age = 16, SSN = "8765432" };
            var mitko = new Student() { Name = "Dimitar", Age = 17, SSN = "7654321" };

            var courseJs = schoolDb
                .Courses
                .Single(c => c.Name == "javascript");

            courseJs.Students.Add(mimi);
            courseJs.Students.Add(tisho);
            courseJs.Students.Add(mitko);

            var rowsAffected = schoolDb.SaveChanges();

            Console.WriteLine($"Rows affected: {rowsAffected} after seed js course");
        }

        public static void PrintAllJsHomeworksOfIvan(SchoolDbContext schoolDb)
        {
            var ivanJsHomeworks = schoolDb
                                          .Homeworks
                                          .Where(hw => hw.Course.Name == "javascript" && hw.Student.Name == "Ivan")
                                          .ToList();

            Console.WriteLine("All homeworks of Ivan for Javascript");
            foreach (var hw in ivanJsHomeworks)
            {
                Console.WriteLine(hw.Content);
            }
        }

        public static void PrintAllHtmlHomeworks(SchoolDbContext schoolDb)
        {
            var htmlHws = schoolDb
                .Homeworks
                .Where(hw => hw.Course.Name == "Html")
                .ToList();

            Console.WriteLine("Homeworks for HTML course: ");
            foreach (var hw in htmlHws)
            {
                Console.WriteLine(hw.Content);
            }
        }

        public static void AddHtmlHw(SchoolDbContext schoolDB)
        {
            var htmlHw = new Homework()
            {
                Content = "get all li tags",
                CourseId = 3,
                StudentId = 3,
                SentTime = DateTime.Now
            };

            schoolDB
                .Homeworks
                .Add(htmlHw);

            var rowsAffected = schoolDB.SaveChanges();
            Console.WriteLine($"Rows affected: {rowsAffected} after add '{htmlHw.Content}' homework");
        }
    }
}
