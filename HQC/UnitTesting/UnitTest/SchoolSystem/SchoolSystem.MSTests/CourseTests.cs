using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolSystem.MSTests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseNameShouldThrowAnExceptionIfNullIsPassed()
        {
            var course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CourseNameShouldThrowExceptionIfEmptyStringIsPassed()
        {
            var course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddStudentShouldThrowAnExceptionIfAddMoreStudentThanCourseCapacity()
        {
            var course = new Course("Math");
            var school = new School("Botev");
            var maxCourseCapacityInStudents = 30;

            for (int i = 0; i < maxCourseCapacityInStudents; i++)
            {
                course.AddStudent(school.CreateSchoolStudent("Student" + i));
            }

            //Adding 31-st student to course
            course.AddStudent(school.CreateSchoolStudent("Ivan"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddStudentShouldThrowAnExceptionIfPassedStudentsIsNull()
        {
            var course = new Course("Math");

            course.AddStudent(null);
        }

        [TestMethod]
        public void EqualsShouldReturnFalseIfTwoCoursesAreWithTheSameNameButDifferentStudents()
        {
            var firstCourse = new Course("Math");
            firstCourse.AddStudent(new SchoolStudent("Ivan", 10000));

            var secondCourse = new Course("Math");

            Assert.IsFalse(firstCourse.Equals(secondCourse));
        }

        [TestMethod]
        public void EqualsShouldReturnTrueIfTwoCoursesAreWithTheSameNameAndTheSametStudents()
        {
            var schoolStud = new SchoolStudent("Ivan", 10000);
            var firstCourse = new Course("Math");
            firstCourse.AddStudent(schoolStud);

            var secondCourse = new Course("Math");
            secondCourse.AddStudent(schoolStud);

            Assert.IsTrue(firstCourse.Equals(secondCourse));
        }
    }
}

