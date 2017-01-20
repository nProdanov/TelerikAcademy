namespace SchoolSsystem
{
    using System;
    using System.Collections.Generic;

    public class School : INameable, ICommentable
    {
        private string name;
        private List<string> comments;
        private List<StudentsClass> classes;

        public School(string name)
        {
            this.comments = new List<string>();
            this.classes = new List<StudentsClass>();
            this.Name = name;
        }

        public List<StudentsClass> Classes
        {
            get
            {
                return this.classes;
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                CheckName(value);
                this.name = value;
            }
        }

        public void AddClass(StudentsClass studClass)
        {
            this.classes.Add(studClass);
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        internal static void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name is empty");
            }
        }
    }
}
