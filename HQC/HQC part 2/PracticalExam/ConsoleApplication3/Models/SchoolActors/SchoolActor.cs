using System;
using System.Text.RegularExpressions;

using SchoolSystem.Contracts.SchoolActors;

namespace SchoolSystem.Models.SchoolActors
{
    public abstract class SchoolActor : ISchoolActor
    {
        private string firstname;
        private string lastName;

        public SchoolActor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstname;
            }

            private set
            {
                this.ValidateName(value);

                this.firstname = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                this.ValidateName(value);

                this.lastName = value;
            }
        }

        private void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Any of names must not be null or empty");
            }

            if (name.Length < 2 || name.Length > 31)
            {
                throw new ArgumentException("The length of any of names must be between 2 and 31 symbols");
            }

            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new ArgumentException("Any of names must contain only characters of the latin alphabet");
            }
        }
    }
}
