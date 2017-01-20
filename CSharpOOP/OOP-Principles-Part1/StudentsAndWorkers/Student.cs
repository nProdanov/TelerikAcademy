namespace StudentsAndWorkers
{
    using System;

    public class Student : Human
    {
        private int grade;

        public Student()
            : base()
        {

        }

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {

        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Grades are from 1 to 12");
                }

                this.grade = value;
            }
        }

        public override string ToString()
        {
            return string.Format("st. {0}-\t{1} grade", base.ToString(), this.Grade);
        }
    }
}
