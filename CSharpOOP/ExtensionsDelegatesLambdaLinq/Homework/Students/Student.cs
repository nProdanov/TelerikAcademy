namespace Homework.Students
{
    using System;
    using System.Collections.Generic;
    using System.Net.Mail;
    using System.Text.RegularExpressions;

    using Extensions;

    public class Student
    {
        private string firstName;
        private string lastName;
        private string facultyNumber;
        private string phoneNumber;
        private MailAddress email;
        private int age;
        private List<Mark> marks;
        private Group group;

        public Student(string firstName, string lastName, MailAddress email, string facultyNumber, int age, Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.FacultyNumber = facultyNumber;
            this.Age = age;
            this.marks = new List<Mark>();
            this.group = group;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.ValidateName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.ValidateName(value);
                this.lastName = value;
            }
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Ivalid Faculty number - null or empty FN");
                }

                if (value.Length != 6)
                {
                    throw new ArgumentOutOfRangeException("Invalid faculty number");
                }

                this.facultyNumber = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                if (value[0] != '+')
                {
                    throw new ArgumentException("Number must begin with + followed by a country code");
                }

                this.phoneNumber = value;
            }
        }

        public MailAddress Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.ValidateEmail(value.Address);
                this.email = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Ivalid age");
                }

                if (value < 7)
                {
                    throw new ArgumentOutOfRangeException("Student is too young");
                }

                this.age = value;
            }
        }

        public List<Mark> Marks
        {
            get
            {
                return new List<Mark>(this.marks);
            }
        }

        public Group Group
        {
            get
            {
                return this.group;
            }
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName + " FN: " + this.FacultyNumber + " " + this.group.DepartmentName + " department";
        }

        public void AddMark(Course course, MarkValue mark)
        {
            this.marks.Add(new Mark(course, mark));
        }

        private void ValidateEmail(string input)
        {
            string firstPart = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))";
            string secondPart = @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            if (!Regex.IsMatch(
                input.Trim(),
                firstPart + secondPart,
                 RegexOptions.IgnoreCase,
                 TimeSpan.FromMilliseconds(250)))
            {
                throw new ArgumentException("Invalid email!");
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Ivalid name - string is null or empty");
            }

            foreach (var letter in name)
            {
                if (!char.IsLetter(letter))
                {
                    throw new ArgumentException("Ivalid name - name can assist only letters");
                }
            }
        }
    }
}
