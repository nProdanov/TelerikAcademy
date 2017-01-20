namespace SchoolSsystem
{
    using System;
    using System.Collections.Generic;

    public class Person : INameable, ICommentable
    {
        private string firstName;
        private string lastName;
        private string fullName;
        private List<string> comments;

        public Person(string firstName, string lastName)
        {
            this.comments = new List<string>();
            this.FirstName = firstName;
            this.LastName = lastName;
            this.fullName = this.FirstName + ' ' + this.LastName;
        }

        public string Name
        {
            get
            {
                return this.fullName;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                School.CheckName(value);
                this.firstName = value;
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
                School.CheckName(value);
                this.lastName = value;
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }
    }
}
