namespace SchoolClient
{
    using System;

    using SchoolSsystem;

    public class TestSchool
    {
        public static void Main()
        {
            var souHristoBotev = new School("SOU Hristo Botev");

            var math = new Discipline("Mathematics", 5, 10);
            var writing = new Discipline("Writing", 6, 12);
            var painting = new Discipline("Painting", 4, 7);
            var sport = new Discipline("Sport", 5, 10);

            var minkov = new Teacher("Gergi", "Minkov");
            minkov.AddDiscipline(sport);
            minkov.AddDiscipline(painting);

            var kolcheva = new Teacher("Slavka", "Kolcheva");
            kolcheva.AddDiscipline(writing);
            kolcheva.AddDiscipline(math);

            var niki = new Student("Nikolay", "Todorv");
            var ivcho = new Student("Ivo", "Jechev");
            var didi = new Student("Daniela", "Petkova");
            var petio = new Student("Petar", "Zhulev");
            var gogo = new Student("Georgi", "Dimitrov");
            var vanio = new Student("Ivan", "Gochev");

            var firstAClass = new StudentsClass("1A");

            // Add Disciplines to class
            firstAClass.AddDiscipline(math);
            firstAClass.AddDiscipline(writing);
            firstAClass.AddDiscipline(painting);
            firstAClass.AddDiscipline(sport);

            // Add teachers to class
            firstAClass.AddTeacher(kolcheva);
            firstAClass.AddTeacher(minkov);
            
            // Add Students to class
            firstAClass.AddStudent(niki);
            firstAClass.AddStudent(ivcho);
            firstAClass.AddStudent(didi);
            firstAClass.AddStudent(petio);
            firstAClass.AddStudent(gogo);
            firstAClass.AddStudent(vanio);

            // Setting numbers to Students in class
            firstAClass.SetOrderInClass();

            // Adding class to the School
            souHristoBotev.AddClass(firstAClass);

            // adding some comments
            firstAClass.AddComment("very wild students");
            firstAClass.AddComment("very high results");

            souHristoBotev.AddComment("excelent school");

            Console.WriteLine(firstAClass);
        }
    }
}
