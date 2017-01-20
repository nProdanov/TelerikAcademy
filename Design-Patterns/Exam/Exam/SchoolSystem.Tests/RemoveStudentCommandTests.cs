
using NUnit.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models.Factories;
using System;
using System.Collections.Generic;
using Telerik.JustMock;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class RemoveStudentCommandTests
    {
        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfCommandParamsAreNull()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new RemoveStudentCommand();

            var expectedContainingMessage = "Command Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(null, mockedTeachersStudentsOperator));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfTeachersStudentsOperatorIsNull()
        {
            var instance = new RemoveStudentCommand();

            var expectedContainingMessage = "Teachers - Students Operator Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(new List<string>(), null));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldCallTeachersStudentsOperatorRemoveStudentMethodWithCorrectParams()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new RemoveStudentCommand();

            instance.Execute(new List<string>() { "1" }, mockedTeachersStudentsOperator);

            Mock.Assert(() => mockedTeachersStudentsOperator.RemoveStudent(Arg.Is<int>(1)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldReturnCorrectString()
        {
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();
            Mock.Arrange(() => mockedTeachersStudentsOperator.RemoveStudent(Arg.IsAny<int>())).DoNothing();

            var instance = new RemoveStudentCommand();
            var result = instance.Execute(new List<string>() { "1" }, mockedTeachersStudentsOperator);

            var expectedResult = $"Student with ID {1} was sucessfully removed.";

            Assert.AreEqual(expectedResult, result);
        }
    }
}
