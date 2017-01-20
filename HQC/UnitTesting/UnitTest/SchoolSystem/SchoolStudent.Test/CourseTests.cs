namespace SchoolStudent.Test
{
    using System;

    using NUnit.Framework;
    using SchoolSystem;

    [TestFixture]
    public class CourseTests
    {
        [Test]
        public void IfNullNamePassedForCourseNameShouldThrowsException()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { new Course(null); });
        }

        [Test]
        public void StudentNameCanNotBeEmpty()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { new Course(string.Empty); });
        }

        [Test]
        public void AddingMoreStudentsThanCourseCapacityCanGetShouldThrowException()
        {
            var course = new Course("Math");
            var school = new School("Botev");
            var maxCourseCapacityInStudents = 30;

            for (int i = 0; i < maxCourseCapacityInStudents; i++)
            {
                course.AddStudent(school.CreateSchoolStudent("Student" + i));
            }

            //Adding 31-st student to course
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { course.AddStudent(school.CreateSchoolStudent("Ivan")); });
        }

        [Test]
        public void AddingNullStudentToCourseShouldThrowException()
        {
            var course = new Course("Math");

            Assert.Throws(typeof(ArgumentNullException), () => { course.AddStudent(null); });
        }
    }
}
