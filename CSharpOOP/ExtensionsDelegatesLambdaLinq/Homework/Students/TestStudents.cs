namespace Homework.Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Mail;

    public static class TestStudents
    {
        public static List<Student> GenerateListStudents()
        {
            var studentsList = new List<Student>();
            studentsList.Add(new Student("Ivan", "Petkov", new MailAddress("kottakova@yahoo.com"), "232306", 18, new Group(GroupNumber.first)));
            studentsList.Add(new Student("Iordan", "Karavelov", new MailAddress("dancho@yahoo.com"), "123406", 25, new Group(GroupNumber.second)));
            studentsList.Add(new Student("Mariana", "Dacheva", new MailAddress("mvb@abv.bg"), "567806", 24, new Group(GroupNumber.third)));
            studentsList.Add(new Student("Yanko", "Genchev", new MailAddress("yakia@gmail.com"), "654305", 28, new Group(GroupNumber.first)));
            studentsList.Add(new Student("Georgi", "Timov", new MailAddress("retarded35@abv.bg"), "987604", 35, new Group(GroupNumber.second)));
            studentsList.Add(new Student("Ivan", "Donchev", new MailAddress("ivan.donchev@abv.bg"), "456707", 20, new Group(GroupNumber.third)));
            studentsList.Add(new Student("Krasimir", "Krasimirov", new MailAddress("tripleK@gmail.com"), "561205", 30, new Group(GroupNumber.second)));

            return studentsList;
        }

        public static List<Student> OrderByDescendingQuery(List<Student> collection)
        {
            var descendingList = (from stud in collection
                                  orderby stud.FirstName descending,
                                  stud.LastName descending
                                  select stud).ToList();

            return descendingList;
        }

        public static List<Student> OrderByDescendingExt(List<Student> collection)
        {
            var descendingList =
                collection
                .OrderByDescending(stud => stud.FirstName)
                .ThenByDescending(stud => stud.LastName)
                .ToList();

            return descendingList;
        }

        public static List<string> FilterByAge(List<Student> collection)
        {
            var filteredList = (from stud in collection
                                where stud.Age > 18 && stud.Age < 24
                                select stud.FirstName + " " + stud.LastName).ToList();

            return filteredList;
        }

        public static List<Student> FilterByFirstNameBeforeLast(List<Student> collection)
        {
            var filteredList = (from stud in collection
                                where stud.FirstName.CompareTo(stud.LastName) < 0
                                select stud).ToList();

            return filteredList;
        }

        public static List<Student> GroupStudsByGroup(List<Student> students, GroupNumber wantedGroup)
        {
            var studentsWantedGroup = (from stud in students
                                       where stud.Group.GroupNumber == wantedGroup
                                       orderby stud.FirstName
                                       select stud).ToList();

            return studentsWantedGroup;
        }

        public static List<Student> GroupStudsByGroupMethods(List<Student> students, GroupNumber wantedGroup)
        {
            var studsWantedGr = students
                .Where(stud => stud.Group.GroupNumber == wantedGroup)
                .OrderBy(stud => stud.FirstName)
                .ToList();

            return studsWantedGr;
        }

        public static List<Student> ExtractSudsByMail(List<Student> students, string domain)
        {
            var studsGroupByEmail = (from stud in students
                                     where stud.Email.Address.Contains(domain)
                                     select stud).ToList();
            if (studsGroupByEmail.Count == 0)
            {
                throw new ArgumentNullException("There is no students with email adress by this domain.");
            }

            return studsGroupByEmail;
        }

        public static List<Student> ExtractStudsByPhone(List<Student> students)
        {
            var studsFromSofia = (from stud in students
                                  where stud.PhoneNumber.Contains("+359882")
                                  select stud).ToList();
            if (studsFromSofia.Count == 0)
            {
                throw new ArgumentNullException("There is no students from Sofia");
            }

            return studsFromSofia;
        }

        public static void ExtractStudsByMakrsCount(List<Student> students, int countOfMarks)
        {
            var extractedStudsByMarkTwo = students
               .Where(stud => stud.Marks.Count == countOfMarks)
               .Select(stud => new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.Marks })
               .ToList();
            if (extractedStudsByMarkTwo.Count == 0)
            {
                throw new ArgumentNullException("There is no students with 2 marks");
            }

            foreach (var stud in extractedStudsByMarkTwo)
            {
                Console.WriteLine("{0}: ", stud.FullName);

                foreach (var mark in stud.Marks)
                {
                    Console.WriteLine(mark);
                }

                Console.WriteLine(new string('-', 5));
            }
        }

        public static void ExtractStudsByMarkSix(List<Student> students)
        {
            var extractedStudsMarkSix = from stud in students
                                        where stud.Marks.Any(mark => mark.CourseMark == MarkValue.Excellent)
                                        select new { FullName = stud.FirstName + " " + stud.LastName, Marks = stud.Marks };
            if (extractedStudsMarkSix.Count() == 0)
            {
                throw new ArgumentNullException("There is no students with mark 6");
            }

            foreach (var stud in extractedStudsMarkSix)
            {
                Console.WriteLine("{0}: ", stud.FullName);

                foreach (var mark in stud.Marks)
                {
                    Console.WriteLine(mark);
                }

                Console.WriteLine(new string('-', 5));
            }
        }

        public static void ExtractStudsByYear(List<Student> students, string lastTwoDigitsOfTheYear)
        {
            var studsFromYear = students
                .Where(stud => stud.FacultyNumber.Substring(4, 2) == lastTwoDigitsOfTheYear)
                .ToList();
            if (studsFromYear.Count == 0)
            {
                throw new ArgumentNullException("There is no students enrolled in this year");
            }

            foreach (var stud in studsFromYear)
            {
                Console.WriteLine("{0}:", stud.FirstName + " " + stud.LastName);

                foreach (var mark in stud.Marks)
                {
                    Console.WriteLine(mark);
                }

                Console.WriteLine(new string('-', 5));
            }
        }

        public static List<Student> ExtractStudsByDepartment(List<Student> students, string department)
        {
            var extractedByDept = students
                .Where(stud => stud.Group.DepartmentName == department)
                .OrderBy(stud => stud.FirstName)
                .ThenBy(stud => stud.LastName)
                .ToList();
            if (extractedByDept.Count == 0)
            {
                throw new ArgumentNullException("There is no students in this department");
            }

            return extractedByDept;
        }

        public static void PrintStudsByGroup(List<Student> students)
        {
            var groups = from stud in students
                         group stud by stud.Group.GroupNumber;

            foreach (var group in groups)
            {
                Console.WriteLine("{0} group: ", group.Key);

                foreach (var stud in group)
                {
                    Console.WriteLine(stud);
                }

                Console.WriteLine(new string('-', 5));
            }
        }

        public static void PrintStudsByDepartment(List<Student> students)
        {
            var groups = students
                .GroupBy(stud => stud.Group.DepartmentName);

            foreach (var group in groups)
            {
                Console.WriteLine("{0} department: ", group.Key);

                foreach (var stud in group)
                {
                    Console.WriteLine(stud);
                }

                Console.WriteLine(new string('-', 5));
            }
        }
    }
}
