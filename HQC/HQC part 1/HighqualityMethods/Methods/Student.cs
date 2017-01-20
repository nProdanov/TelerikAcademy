using System;

namespace Methods
{
    public class Student
    {
        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string OtherInfo { get; set; }
        
        public bool IsOlderThan(Student other)
        {
            var isOlder = HelpMethods.CompareAges(this.OtherInfo, other.OtherInfo) > 0;

            return isOlder;
        }
    }
}
