using System;
using System.Linq;

using NUnit.Framework;
using Telerik.JustMock;

using SchoolSystem.Tests.Mocks;
using System.Text;
using SchoolSystem.Models.SchoolActors;
using SchoolSystem.Contracts;
using SchoolSystem.Types;

namespace SchoolSystem.Tests.ModelsTests.SchoolActorsTests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void StudentConstructorMustSetFirstNameIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;

            var testStudent = new Student(validFirstName, validLastName, validGrade);

            Assert.AreEqual(validFirstName, testStudent.FirstName);
        }

        [Test]
        public void StudentConstructorMustSetLastNameIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;

            var testStudent = new Student(validFirstName, validLastName, validGrade);

            Assert.AreEqual(validLastName, testStudent.LastName);
        }

        [Test]
        public void StudentConstructorMustSetCorrectGradeIfPassedValuesAreValid()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;

            var testStudent = new Student(validFirstName, validLastName, validGrade);

            Assert.AreEqual(validGrade, testStudent.Grade);
        }

        [TestCase("A")]
        [TestCase("Qwertyuiopasdfghjklzxcvbnmqwertyuiop")]
        public void StudentConstructorShouldThrowWithCorrectMessageIfPassNoValidLengthFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validGrade = 2;
            var expectedContainingMessage = "The length of any of names must be between 2 and 31 symbols";

            var ex = Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, validLastName, validGrade));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [TestCase(null)]
        [TestCase("")]
        public void StudentConstructorShouldThrowWithCorrectMessageIfPassNullOrEmptyStringForFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validGrade = 2;
            var expectedContainingMessage = "Any of names must not be null or empty";

            var ex = Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, validLastName, validGrade));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [TestCase("Qweq12")]
        [TestCase("QWeqw-")]
        public void StudentConstructorShouldThrowWithCorrectMessageIfPassStringWithNoLettersSymbolsForFirstname(string invalidFirstName)
        {
            var validLastName = "Last";
            var validGrade = 2;
            var expectedContainingMessage = "Any of names must contain only characters of the latin alphabet";

            var ex = Assert.Throws<ArgumentException>(() => new Student(invalidFirstName, validLastName, validGrade));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [TestCase(13)]
        [TestCase(0)]
        [TestCase(-1)]
        public void StudentConstructorShouldThrowWithCorrectMessageIfPassInvalidNumberForGrade(int invaligGrade)
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var expectedContainingMessage = "Grade Must be in range 1 and 12";

            var ex = Assert.Throws<ArgumentException>(() => new Student(validFirstName, validLastName, invaligGrade));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }

        [Test]
        public void GetMarkShouldThrowExceptionWithCorrectMessageIfStudentAddMoreThan20Marks()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;
            var expectedContainingMessage = "Marks must be even or less than 20";

            var testStudent = new Student(validFirstName, validLastName, validGrade);
            var mockedMark = Mock.Create<IMark>();

            for (int i = 0; i < 20; i++)
            {
                testStudent.GetMark(mockedMark);
            }

            var ex = Assert.Throws<ArgumentException>(() => testStudent.GetMark(mockedMark));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }
       
        [Test]
        public void GetMarkShouldAddMarkToStudentsMarks()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;

            var testStudent = new MockedStudent(validFirstName, validLastName, validGrade);
            var mockedMark = Mock.Create<IMark>();

            testStudent.GetMark(mockedMark);

            Assert.AreEqual(1, testStudent.GetMarks.Count());
        }

        [Test]
        public void ListMarksShouldReturnCorrectString()
        {
            var validFirstName = "First";
            var validLastName = "Last";
            var validGrade = 2;

            var testStudent = new MockedStudent(validFirstName, validLastName, validGrade);
            var mockedMark = Mock.Create<IMark>();
            Mock.Arrange(() => mockedMark.Subject).Returns(SubjectType.Bulgarian);
            Mock.Arrange(() => mockedMark.Value).Returns(4);


            var expected = new StringBuilder();
            expected.AppendLine("The student has these marks:");
            expected.AppendLine("Bulgarian => 4");

            testStudent.GetMark(mockedMark);

            Assert.AreEqual(expected.ToString(), testStudent.ListMarks());
        }
    }
}
