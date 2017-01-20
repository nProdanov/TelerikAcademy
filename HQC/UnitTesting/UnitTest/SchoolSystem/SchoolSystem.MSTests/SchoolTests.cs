using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolSystem.MSTests
{
    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void GenereteUniqueNumbersShouldReturnFirstUniqueNumberIfOneSchoolStudentCreated()
        {
            int countStudents = 1;
            int expectedUniqueNumerOfLastStudent = 10000;
            var school = new School("Botev");
            var stud = school.CreateSchoolStudent("stud");

            for (int i = 1; i < countStudents; i++)
            {
                stud = school.CreateSchoolStudent("stud");
            }

            Assert.AreEqual(expectedUniqueNumerOfLastStudent, stud.UniqueNumber);
        }

        [TestMethod]
        public void GenereteUniqueNumbersShouldReturnLastUniqueNumberIfCreated90000SchoolStudents()
        {
            int countStudents = 90000;
            int expectedUniqueNumerOfLastStudent = 99999;
            var school = new School("Botev");
            var stud = school.CreateSchoolStudent("stud");

            for (int i = 1; i < countStudents; i++)
            {
                stud = school.CreateSchoolStudent("stud");
            }

            Assert.AreEqual(expectedUniqueNumerOfLastStudent, stud.UniqueNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateSchoolStudentShouldThrowAnExceptionIfCreateMoreStudentsThanSchoolCapacity()
        {

            var school = new School("Botev");
            var maxSchoolCapacityInStudents = 90000;

            for (int i = 0; i < maxSchoolCapacityInStudents; i++)
            {
                school.CreateSchoolStudent("stud" + i);
            }

            //Adding 90001-st student
            school.CreateSchoolStudent("studOverCapacity");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchooNameShouldThrowExceptoinIfNullIsPassed()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SchooNameShouldThrowExceptoinIfEmptyStringIsPassed()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddCourseShouldThrowAnExceptionIfPassedCourseIsNull()
        {
            var school = new School("Botev");

            school.AddCourse(null);
        }

        [TestMethod]
        public void AddCourseShouldAddCourseInSchoolCoursesWhenNonNullCourseIsPassed()
        {
            var school = new School("Botev");
            var course = new Course("Math");

            school.AddCourse(course);

            Assert.AreEqual(course, school.Courses.FirstOrDefault());
        }

        [TestMethod]
        public void RemoveCourseShouldRemoveTheCourseFromCourses()
        {
            var school = new School("Botev");
            var course = new Course("Math");
            var expectedCoursesCountAfterRemoving = 0;

            school.AddCourse(course);
            school.RemoveCourse(course);

            Assert.AreEqual(expectedCoursesCountAfterRemoving, school.Courses.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudentToCourseShouldThrowExceptionIfPassedCourseIsNull()
        {
            var student = new SchoolStudent("Ivan", 10000);
            var school = new School("Botev");

            school.AddStudentToCourse(null, student);
        }

        [TestMethod]
        public void AddStudentToCourseShouldAddStudentToCourseIfCourseAppearsInCourses()
        {
            var student = new SchoolStudent("Ivan", 10000);
            var school = new School("Botev");
            var course = new Course("Math");
            var expectedCourseStudentsAfterAdd = 1;

            school.AddCourse(course);
            school.AddStudentToCourse(course, student);

            Assert.AreEqual(expectedCourseStudentsAfterAdd, school.Courses.FirstOrDefault().Students.Count());
        }

        [TestMethod]
        public void RemoveStudentFromCourseShouldRemoveStudentFromSelectedCourseIfCourseAppearsInCoursesAndStudentAppearsInCourse()
        {
            var school = new School("Botev");
            var student = school.CreateSchoolStudent("Ivan");
            var anotherStudent = school.CreateSchoolStudent("Dragan");
            var course = new Course("Math");
            int expectedCourseStudentsAfterRemove = 1;

            school.AddCourse(course);
            school.AddStudentToCourse(course, student);
            school.AddStudentToCourse(course, anotherStudent);
            school.RemoveStudentFromCourse(course, student);


            Assert.AreEqual(expectedCourseStudentsAfterRemove, school.Courses.FirstOrDefault().Students.Count());
        }
    }
}