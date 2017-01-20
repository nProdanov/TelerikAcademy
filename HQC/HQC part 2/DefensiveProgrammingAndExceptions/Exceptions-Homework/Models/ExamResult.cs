using System;

using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Models
{
    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }
            private set
            {
                Validator.ValidateIfNonNegativeNumber(value, "Grade");
                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }
            private set
            {
                Validator.ValidateIfNonNegativeNumber(value, "Min Grade");
                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }
            private set
            {
                if (value <= this.minGrade)
                {
                    throw new ArgumentException("Max Grade must be greater than a min grade");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }
            private set
            {
                Validator.ValidateIfStringIsValid(value, "Comments");

                this.comments = value;
            }
        }
    }
}