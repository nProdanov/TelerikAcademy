using System;

using SchoolSystem.Framework.Models.Abstractions;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Framework.Models
{
    public class Teacher : Person, ITeacher
    {
        public const int MaxStudentMarksCount = 20;
        private IMarksFactory marksFactory;

        public Teacher(string firstName, string lastName, Subject subject, IMarksFactory marksFactory)
            : base(firstName, lastName)
        {
            if (marksFactory == null)
            {
                throw new ArgumentNullException("Marks factory cannot be null");
            }

            this.marksFactory = marksFactory;
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(IStudent student, float mark)
        {
            if (student.Marks.Count >= MaxStudentMarksCount)
            {
                throw new ArgumentException($"The student's marks count exceed the maximum count of {MaxStudentMarksCount} marks");
            }

            var newMark = this.marksFactory.CreateMark(this.Subject, mark);
            student.Marks.Add(newMark);
        }
    }
}
