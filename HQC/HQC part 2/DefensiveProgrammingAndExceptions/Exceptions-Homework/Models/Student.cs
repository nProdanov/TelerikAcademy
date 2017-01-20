using System;
using System.Collections.Generic;
using System.Linq;

using ExceptionsHomework.Models.Exams.Contracts;
using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Models
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<IExam> exams;

        public Student(string firstName, string lastName, IList<IExam> exams = null)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Exams = exams;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                Validator.ValidateIfStringIsValid(value, "First name");

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
                Validator.ValidateIfStringIsValid(value, "Last name");

                this.lastName = value;
            }
        }

        public IList<IExam> Exams
        {
            get
            {
                return new List<IExam>(this.exams);
            }
            set
            {
                if (value != null)
                {
                    this.exams = value;
                }
                else
                {
                    this.exams = new List<IExam>();
                }
            }
        }

        public IList<ExamResult> CheckExams()
        {
            if (this.Exams.Count == 0)
            {
                throw new ArgumentException("Cannot Check exams if there are not exams");
            }

            var results = new List<ExamResult>();
            for (int i = 0; i < this.Exams.Count; i++)
            {
                results.Add(this.Exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.Exams.Count == 0)
            {
                throw new ArgumentException("Canot Calculate average results if there are not exams");
            }

            double[] examScore = new double[this.Exams.Count];
            IList<ExamResult> examResults = this.CheckExams();

            for (int i = 0; i < examResults.Count; i++)
            {
                examScore[i] =
                    ((double)examResults[i].Grade - examResults[i].MinGrade) /
                    (examResults[i].MaxGrade - examResults[i].MinGrade);
            }

            return examScore.Average();
        }
    }
}