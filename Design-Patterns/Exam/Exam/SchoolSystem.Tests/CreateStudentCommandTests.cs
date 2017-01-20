using System;
using System.Collections.Generic;

using NUnit.Framework;

using Telerik.JustMock;

using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void ConstructorShouldThrowArgumentExceptionWithMessageIfPassedParamIsNull()
        {
            var expectedContainingMessage = "Students factory cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(null));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ConstructorShouldReturnNewInstaceOfCreateStudentCommandIfPassedParamIsNotNull()
        {
            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();

            var instance = new CreateStudentCommand(mockedStudentsFactory);
            Assert.IsInstanceOf<CreateStudentCommand>(instance);
        }

        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfCommandParamsAreNull()
        {
            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new CreateStudentCommand(mockedStudentsFactory);

            var expectedContainingMessage = "Command Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(null, mockedTeachersStudentsOperator));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldThrowArgumentNullExceptionIfTeachersStudentsOperatorIsNull()
        {
            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();

            var instance = new CreateStudentCommand(mockedStudentsFactory);

            var expectedContainingMessage = "Teachers - Students Operator Parameteres cannot be null";

            ArgumentNullException ex = Assert.Throws<ArgumentNullException>(() => instance.Execute(new List<string>(), null));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void ExecuteShouldCallStudentsFactoryCreateStudentMethodWithCorrectParams()
        {
            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();

            var firstName = "first";
            var lastName = "last";
            var grade = Grade.Eighth;
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new CreateStudentCommand(mockedStudentsFactory);


            instance.Execute(new List<string>() { firstName, lastName, "8" }, mockedTeachersStudentsOperator);
            Mock.Assert(() => mockedStudentsFactory.CreateStudent(Arg.Is<string>(firstName), Arg.Is<string>(lastName), Arg.Is<Grade>(grade)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldCallTeachersStudentsOperatorAddStudentMethodWithCorrectParams()
        {
            var mockedStudent = Mock.Create<IStudent>();

            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();
            var firstName = "first";
            var lastName = "last";
            var grade = Grade.Eighth;
            Mock.Arrange(() => mockedStudentsFactory.CreateStudent(firstName, lastName, grade)).Returns(mockedStudent);

            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();

            var instance = new CreateStudentCommand(mockedStudentsFactory);


            instance.Execute(new List<string>() { firstName, lastName, "8" }, mockedTeachersStudentsOperator);
            Mock.Assert(() => mockedTeachersStudentsOperator.AddStudent(Arg.Is<int>(0), Arg.Is<IStudent>(mockedStudent)), Occurs.Once());
        }

        [Test]
        public void ExecuteShouldIncrementStudentIdWhenCalledTwice()
        {
            var mockedStudent = Mock.Create<IStudent>();

            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();
            Mock.Arrange(() => mockedStudentsFactory.CreateStudent(Arg.IsAny<string>(), Arg.IsAny<string>(), Arg.IsAny<Grade>())).DoNothing();

            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();
            Mock.Arrange(() => mockedTeachersStudentsOperator.AddStudent(Arg.IsAny<int>(), Arg.IsAny<IStudent>())).DoNothing();

            var instance = new CreateStudentCommand(mockedStudentsFactory);
            var firstName = "first";
            var lastName = "last";
            var grade = Grade.Eighth;

            var expectedResult = $"A new student with name {firstName} {lastName}, grade {grade} and ID {1} was created.";

            instance.Execute(new List<string>() { firstName, lastName, "8" }, mockedTeachersStudentsOperator);
            var result = instance.Execute(new List<string>() { firstName, lastName, "8" }, mockedTeachersStudentsOperator);

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void ExecuteShouldReturnCorrectString()
        {
            var mockedStudent = Mock.Create<IStudent>();

            var mockedStudentsFactory = Mock.Create<IStudentsFactory>();
            Mock.Arrange(() => mockedStudentsFactory.CreateStudent(Arg.IsAny<string>(), Arg.IsAny<string>(), Arg.IsAny<Grade>())).DoNothing();
            
            var mockedTeachersStudentsOperator = Mock.Create<ITeachersStudentsOperator>();
            Mock.Arrange(() => mockedTeachersStudentsOperator.AddStudent(Arg.IsAny<int>(), Arg.IsAny<IStudent>())).DoNothing();

            var instance = new CreateStudentCommand(mockedStudentsFactory);
            var firstName = "first";
            var lastName = "last";
            var grade = Grade.Eighth;

            var expectedResult = $"A new student with name {firstName} {lastName}, grade {grade} and ID {0} was created.";

            var result = instance.Execute(new List<string>() { firstName, lastName, "8" }, mockedTeachersStudentsOperator);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
