using System;

using NUnit.Framework;
using Telerik.JustMock;

using SchoolSystem.Contracts;
using SchoolSystem.Contracts.SchoolActors;
using SchoolSystem.Models.SchoolActors;
using SchoolSystem.Types;

namespace SchoolSystem.Tests.ModelsTests.SchoolActorsTests
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void TeacherConstructorMustSetFirstNameIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;

            var testTeacher = new Teacher(validFirstName, validLastName, validSubject);

            Assert.AreEqual(validFirstName, testTeacher.FirstName);
        }

        [Test]
        public void TeacherConstructorMustSetLastNameIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;

            var testTeacher = new Teacher(validFirstName, validLastName, validSubject);

            Assert.AreEqual(validLastName, testTeacher.LastName);
        }

        [Test]
        public void TeacherConstructorMustSetCorrectSubjectIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;

            var testTeacher = new Teacher(validFirstName, validLastName, validSubject);

            Assert.AreEqual(validSubject, testTeacher.Subject);
        }

        [TestCase("A")]
        [TestCase("Qwertyuiopasdfghjklzxcvbnmqwertyuiop")]
        public void TeacherConstructorShouldThrowWithCorrectMessageIfPassNoValidLengthFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;
            var expectedContainingMessage = "The length of any of names must be between 2 and 31 symbols";

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(invalidFirstName, validLastName, validSubject));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        public void TeacherConstructorShouldThrowWithCorrectMessageIfPassNullOrEmptyStringForFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;
            var expectedContainingMessage = "Any of names must not be null or empty";

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(invalidFirstName, validLastName, validSubject));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [TestCase("Qweq12")]
        [TestCase("QWeqw-")]
        public void TeacherConstructorShouldThrowWithCorrectMessageIfPassStringWithNoLettersSymbolsForFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;
            var expectedContainingMessage = "Any of names must contain only characters of the latin alphabet";

            var ex = Assert.Throws<ArgumentException>(() => new Teacher(invalidFirstName, validLastName, validSubject));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void AddMarkShouldCallStundetMethodGetMarkWithPassedMark()
        {
            var mockedStudent = Mock.Create<IStudent>();
            var mockedMark = Mock.Create<IMark>();

            var validFirstName = "First";
            var validLastName = "Last";
            var validSubject = SubjectType.Bulgarian;
            var validTeacher = new Teacher(validFirstName, validLastName, validSubject);

            validTeacher.AddMark(mockedStudent, mockedMark);

            Mock.Assert(() => mockedStudent.GetMark(mockedMark), Occurs.Once());
        }

    }
}
