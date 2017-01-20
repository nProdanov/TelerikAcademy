using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolSystem.MSTests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentNameShouldThrowAnExceptionIfNullIsPassed()
        {
            var schoolStudent = new SchoolStudent(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentNameSHouldThrowAnExceptionIfEmptyStringIsPassed()
        {
            var schoolStudent = new SchoolStudent(string.Empty, 10000); 
        }
    }
}
