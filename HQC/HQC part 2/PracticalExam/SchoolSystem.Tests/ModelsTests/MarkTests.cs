using System;

using NUnit.Framework;
using SchoolSystem.Types;
using SchoolSystem.Models.SchoolActors;

namespace SchoolSystem.Tests.ModelsTests
{
    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void MarkConstruCtorShouldSetCorrectValueIfPassValidParams()
        {
            var validSubject = SubjectType.English;
            var validValue = 5;

            var testMark = new Mark(validSubject, validValue);

            Assert.AreEqual(validValue, testMark.Value);
        }

        [Test]
        public void MarkConstruCtorShouldSetCorrectSubjectIfPassValidParams()
        {
            var validSubject = SubjectType.English;
            var validValue = 5;

            var testMark = new Mark(validSubject, validValue);

            Assert.AreEqual(validSubject, testMark.Subject);
        }

        [TestCase(1)]
        [TestCase(1)]
        [TestCase(0)]
        [TestCase(-1)]
        public void MarkConstructorShouldThrowWithCorrectMessageIfValueIsInvalid(int invalidValue)
        {
            var validSubject = SubjectType.English;
            var expectedContainingMessage = "Mark value must be in range";

            var ex = Assert.Throws<ArgumentException>(() => new Mark(validSubject, invalidValue));
            Assert.That(ex.Message.Contains(expectedContainingMessage));
        }
    }
}
