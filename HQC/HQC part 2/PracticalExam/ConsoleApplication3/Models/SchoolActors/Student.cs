using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using SchoolSystem.Contracts;
using SchoolSystem.Contracts.SchoolActors;

namespace SchoolSystem.Models.SchoolActors
{
    public class Student : SchoolActor, IStudent
    {
        private int grade;
        private List<IMark> marks;

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
            this.marks = new List<IMark>();
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            set
            {
                this.ValidateGrade(value);

                this.grade = value;
            }
        }

        protected IEnumerable<IMark> Marks
        {
            get
            {
                return this.marks;
            }
        }

        public void GetMark(IMark mark)
        {
            if (this.marks.Count < 20)
            {
                this.marks.Add(mark);
            }
            else
            {
                throw new ArgumentException("Marks must be even or less than 20");
            }
        }

        public string ListMarks()
        {
            var result = new StringBuilder();
            result.AppendLine("The student has these marks:");

            var marks = this.marks.Select(m => $"{m.Subject} => {m.Value}").ToList();

            foreach (var mark in marks)
            {
                result.AppendLine(mark);
            }

            return result.ToString();
        }

        private void ValidateGrade(int grade)
        {
            if (grade < 1 || grade > 12)
            {
                throw new ArgumentException("Grade Must be in range 1 and 12");
            }
        }
    }
}
