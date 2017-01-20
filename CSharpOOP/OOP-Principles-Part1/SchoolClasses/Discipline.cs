namespace SchoolSsystem
{
    using System;
    using System.Collections.Generic;

    public class Discipline : INameable, ICommentable
    {
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        private List<string> comments;

        public Discipline(string name, int numberOfLectures, int numberOfExercises)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
            this.comments = new List<string>();
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Lectures can not be less than 1");
                }

                this.numberOfLectures = value;
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Exercesise can not be less than 1");
                }

                this.numberOfExercises = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                School.CheckName(value);
                this.name = value;
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
