namespace SchoolSystem.Test
{
    using System;

    using NUnit.Framework;
    using SchoolSystem;

    [TestFixture]
    public class StudentTest
    {
        [Test]
        public void StudentNameCanNotBeNull()
        {
            Assert.Throws(typeof(ArgumentNullException), () => { new SchoolStudent(null, 10000); });
        }

        [Test]
        public void StudentNameCanNotBeEmpty()
        {
            Assert.Throws(typeof(ArgumentOutOfRangeException), () => { new SchoolStudent(string.Empty, 10000); });
        }
    }
}
