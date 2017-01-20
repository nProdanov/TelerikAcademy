using NUnit.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfCommandParamsAreNull()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new TeacherAddMarkCommand();

            var expectedContainingMessage = "Command Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(null, mockedTeachersStudentsOperator));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfTeachersStudentsOperatorIsNull()
        {
            var instance = new TeacherAddMarkCommand();

            var expectedContainingMessage = "Teachers - Students Operator Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(new List<string>(), null));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldCallTeachersStudentsOperatorGethStudentWithCorrectParams()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new TeacherAddMarkCommand();

            instance.Execute(new List<string>() { "1", "2", "4.5" }, mockedTeachersStudentsOperator);

            Mock.Assert(() => mockedTeachersStudentsOperator.GetStudentById(Arg.Is<int>(2)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldCallTeachersStudentsOperatorGethTeacherWithCorrectParams()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new TeacherAddMarkCommand();

            instance.Execute(new List<string>() { "1", "2", "4.5" }, mockedTeachersStudentsOperator);

            Mock.Assert(() => mockedTeachersStudentsOperator.GetTeacherById(Arg.Is<int>(1)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldCallTeacherAddMarkMethodWithCorrectParams()
        {
            var mockedStudent = Mock.Create<IStudent>();
            var mockedTeacher = Mock.Create<ITeacher>();

            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();
            Mock.Arrange(() => mockedTeachersStudentsOperator.GetStudentById(Arg.IsAny<int>())).Returns(mockedStudent);
            Mock.Arrange(() => mockedTeachersStudentsOperator.GetTeacherById(Arg.IsAny<int>())).Returns(mockedTeacher);

            var instance = new TeacherAddMarkCommand();

            instance.Execute(new List<string>() { "1", "2", "4.5" }, mockedTeachersStudentsOperator);

            Mock.Assert(() => mockedTeacher.AddMark(Arg.Is<IStudent>(mockedStudent), Arg.Is<float>(4.5f)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldReturnCorrectString()
        {
            var studentFirstName = "pesho";
            var studentLastName = "peshov";
            var mockedStudent = Mock.Create<IStudent>();
            Mock.Arrange(() => mockedStudent.FirstName).Returns(studentFirstName);
            Mock.Arrange(() => mockedStudent.LastName).Returns(studentLastName);

            var teacherFirstName = "gosho";
            var teacherLastName = "goshov";
            var teacherSubject = Subject.Bulgarian;
            var mockedTeacher = Mock.Create<ITeacher>();
            Mock.Arrange(() => mockedTeacher.FirstName).Returns(teacherFirstName);
            Mock.Arrange(() => mockedTeacher.LastName).Returns(teacherLastName);
            Mock.Arrange(() => mockedTeacher.Subject).Returns(teacherSubject);

            Mock.Arrange(() => mockedTeacher.AddMark(Arg.IsAny<IStudent>(), Arg.IsAny<float>())).DoNothing();

            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();
            Mock.Arrange(() => mockedTeachersStudentsOperator.GetStudentById(Arg.IsAny<int>())).Returns(mockedStudent);
            Mock.Arrange(() => mockedTeachersStudentsOperator.GetTeacherById(Arg.IsAny<int>())).Returns(mockedTeacher);

            var instance = new TeacherAddMarkCommand();

            var result = instance.Execute(new List<string>() { "1", "2", "4.5" }, mockedTeachersStudentsOperator);

            var expectedResult = $"Teacher {teacherFirstName} {teacherLastName} added mark {4.5} to student {studentFirstName} {studentLastName} in {teacherSubject}.";

            Assert.AreEqual(expectedResult, result); 
        }
    }
}
