using System;
using System.Data.Entity.Migrations;

using SchoolSystem.Models;

namespace SchoolSystem.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<SchoolDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "SchoolSystem.Data.SchoolDbContext";
        }

        protected override void Seed(SchoolDbContext context)
        {
            var input = new Homework() { Content = "Read from console", SentTime = DateTime.Now, CourseId = 1, StudentId = 1 };
            var dataTypes = new Homework() { Content = "Find all prime numbers", SentTime = DateTime.Now, CourseId = 1, StudentId = 2 };
            var loops = new Homework() { Content = "Write loop to 1000000", SentTime = DateTime.Now, CourseId = 2, StudentId = 1 };
            var tags = new Homework() { Content = "Make table with 10 rows and 10 columns", SentTime = DateTime.Now, CourseId = 3, StudentId = 3 };

            context.Homeworks.AddOrUpdate(
                hw => hw.Content,
                input,
                tags,
                loops,
                dataTypes);

            var csharp = new Course() { Name = "c#", Desctiption = "fundamentals", Id = 1 };
            var js = new Course() { Name = "javascript", Desctiption = "js for advanced", Id = 2 };
            var html = new Course() { Name = "Html", Desctiption = "hyper text markup laguage", Id = 3 };

            var ivan = new Student() { Name = "Ivan", SSN = "1234567", Age = 12, Id = 1 };
            ivan.Courses.Add(csharp);
            ivan.Courses.Add(js);

            var niki = new Student() { Name = "Nikolay", SSN = "1234568", Age = 13, Id = 2 };
            niki.Courses.Add(csharp);

            var pesho = new Student() { Name = "Pesho", SSN = "1234565", Age = 14, Id = 3 };
            pesho.Courses.Add(js);
            pesho.Courses.Add(html);

            context.Students.AddOrUpdate(
                st => st.SSN,
                ivan,
                niki,
                pesho);
        }
    }
}
