using System.Collections.Generic;

using SchoolSystem.Contracts;
using SchoolSystem.Models.SchoolActors;

namespace SchoolSystem.Tests.Mocks
{
    public class MockedStudent : Student
    {
        public MockedStudent(string firstName, string lastName, int grade) 
            : base(firstName, lastName, grade)
        {
        }

        public IEnumerable<IMark> GetMarks
        {
            get
            {
                return this.Marks;
            }
        }
    }
}
