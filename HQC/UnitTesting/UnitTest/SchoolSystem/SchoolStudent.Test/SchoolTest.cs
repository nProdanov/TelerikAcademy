namespace SchoolStudent.Test
{
    using System;
    using System.Linq;

    using NUnit.Framework;
    using SchoolSystem;

    [TestFixture]
    public class SchoolTest
    {
        [TestCase(1, 10000)]
        [TestCase(90000, 99999)]
        public void UniqueNumberShouldGrowsWithEveryNewSchoolStudent(int countStudents, int expectedUniqueNumerOfLastStudent)
        {
            var school = new School("Botev");
            var stud = school.CreateSchoolStudent("stud");

            for (int i = 1; i < countStudents; i++)
            {
                stud = school.CreateSchoolStudent("stud");
            }

            Assert.AreEqual(expectedUniqueNumerOfLastStudent, stud.UniqueNumber);
        }

        [Test]
        public void IfCreateMoreStudentThanSchoolCapacityShouldThrowsException()
        {

            var school = new School("Botev");
            var maxSchoolCapacityInStudents = 90000;

            for (int i = 0; i < maxSchoolCapacityInStudents; i++)
            {
                school.CreateSchoolStudent("stud" + i);
            }

            //Adding 90001-st student
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => school.CreateSchoolStudent("studOverCapacity"));
        }

        [Test]
        public void IfNullSchoolNamePassedShouldThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { new School(null); });
        }

        [Test]
        public void IfEmptyStringPassedForSchoolNameShouldTrowsException()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { new School(string.Empty); });
        }

        [Test]
        public void IfAddingNullCourseToSchoolShouldThrowException()
        {
            var school = new School("Botev");

            Assert.Throws(typeof(ArgumentNullException), () => { school.AddCourse(null); });
        }

        [Test]
        public void AddingCourseToSchoolShouldAppearNewCourseInCourses()
        {
            var school = new School("Botev");
            var course = new Course("Math");

            school.AddCourse(course);

            Assert.AreEqual(course, school.Courses.FirstOrDefault());
        }

        [Test]
        public void RemovingCourseFromSchoolShouldRemoveTheCourseFromCourses()
        {
            var school = new School("Botev");
            var course = new Course("Math");
            var expectedCoursesCountAfterRemoving = 0;

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(expectedCoursesCountAfterRemoving, school.Courses.Count());
        }

        [Test]
        public void AddingStudentToANullCourseShouldThrowExcepetion()
        {
            var student = new SchoolStudent("Ivan", 10000);
            var school = new School("Botev");

            Assert.Throws(typeof(ArgumentNullException), () => { school.AddStudentToCourse(null, student); });
        }

        [Test]
        public void IfTwoCoursesWithSameNameCompareShouldReturnFalseIfStudentsInThereAreDifferent()
        {
            var firstCourse = new Course("Math");
            firstCourse.AddStudent(new SchoolStudent("Ivan", 10000));

            var secondCourse = new Course("Math");

            Assert.IsFalse(firstCourse.Equals(secondCourse));
        }
    }
}
