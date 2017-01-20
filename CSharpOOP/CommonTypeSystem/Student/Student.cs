namespace Student
{
    using System;
    using System.Net.Mail;
    using System.Text;

    using Enumerations;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(
            string firstName,
            string middleName,
            string lastName,
            string ssn,
            string address,
            string mobileNumber,
            string email,
            int course,
            University university,
            Faculty faculty,
            Specialty spec)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SocialSecurityNumber = ssn;
            this.Address = address;
            this.PhoneNumber = mobileNumber;
            this.Email = new MailAddress(email);
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Specialty = spec;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public MailAddress Email { get; set; }

        public int Course { get; set; }

        public University University { get; set; }

        public Faculty Faculty { get; set; }

        public Specialty Specialty { get; set; }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        public override int GetHashCode()
        {
            var hashCode = this.SocialSecurityNumber.GetHashCode() ^ this.MiddleName.GetHashCode();
            return hashCode;
        }

        public override bool Equals(object obj)
        {
            var anotherStud = obj as Student;
            if (anotherStud != null)
            {
                if (this.University != anotherStud.University)
                {
                    return false;
                }

                if (this.Faculty != anotherStud.Faculty)
                {
                    return false;
                }

                if (this.Specialty != anotherStud.Specialty)
                {
                    return false;
                }

                if (this.Course != anotherStud.Course)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append("Student:");
            result.AppendLine(string.Format("Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName));
            result.AppendLine(string.Format("SSN: {0}", this.SocialSecurityNumber));
            result.AppendLine(string.Format("University: {0}", this.University));
            result.AppendLine(string.Format("Faculty: {0}", this.Faculty));
            result.AppendLine(string.Format("Specialty: {0}", this.Specialty));
            result.AppendLine(string.Format("Course: {0}", this.Course));
            result.AppendLine(string.Format("Permanent address: {0}", this.Address));
            result.AppendLine(string.Format("E-mail address: {0}", this.Email.Address));
            result.AppendLine(string.Format("Phone number: {0}", this.PhoneNumber));
            return result.ToString();
        }

        public object Clone()
        {
            var clone = new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.SocialSecurityNumber,
                this.Address,
                this.PhoneNumber,
                this.Email.Address,
                this.Course,
                this.University,
                this.Faculty,
                this.Specialty);

            return clone;
        }

        public int CompareTo(Student otherStud)
        {
            if (this.FirstName.CompareTo(otherStud.FirstName) < 0)
            {
                return -1;
            }

            if (this.FirstName.CompareTo(otherStud.FirstName) > 0)
            {
                return 1;
            }

            if (this.MiddleName.CompareTo(otherStud.MiddleName) < 0)
            {
                return -1;
            }

            if (this.MiddleName.CompareTo(otherStud.MiddleName) > 0)
            {
                return 1;
            }

            if (this.LastName.CompareTo(otherStud.LastName) < 0)
            {
                return -1;
            }

            if (this.LastName.CompareTo(otherStud.LastName) > 0)
            {
                return 1;
            }

            if (long.Parse(this.SocialSecurityNumber).CompareTo(long.Parse(otherStud.SocialSecurityNumber)) < 0)
            {
                return -1;
            }

            if (long.Parse(this.SocialSecurityNumber).CompareTo(long.Parse(otherStud.SocialSecurityNumber)) > 0)
            {
                return 1;
            }

            return 0;
        }
    }
}
