using ExceptionsHomework.Models.Types;
using ExceptionsHomework.Models.Exams.Contracts;
using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Models.Exams
{
    public class SimpleMathExam : IExam
    {
        private const int ProblemsSolvedForPass = 3;
        private const int ProblemsSolvedForAverageGrade = 5;
        private const int ProblemsSolvedForVeryGoodGrade = 7;
        private const int ProblemsSolvedForExcellentGrade = 9;

        private const int MinProblemsSolved = 0;
        private const int MaxProblemsSolved = 10;

        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }
            private set
            {
                Validator.ValidateIfNumberInRange(
                    value,
                    SimpleMathExam.MinProblemsSolved,
                    SimpleMathExam.MaxProblemsSolved,
                    "Problems solved");

                this.problemsSolved = value;
            }
        }

        public ExamResult Check()
        {
            if (this.ProblemsSolved >= SimpleMathExam.ProblemsSolvedForExcellentGrade)
            {
                return new ExamResult(
                    (int)Grades.MaxGrade,
                    (int)Grades.MinGrade,
                    (int)Grades.MaxGrade,
                    "Excelent result: everything done!");
            }

            if (this.ProblemsSolved >= SimpleMathExam.ProblemsSolvedForVeryGoodGrade)
            {
                return new ExamResult(
                    (int)Grades.VeryGoodGrade,
                    (int)Grades.MinGrade,
                    (int)Grades.MaxGrade,
                    "Very good results: almost everything done!");
            }

            if (this.ProblemsSolved >= SimpleMathExam.ProblemsSolvedForAverageGrade)
            {
                return new ExamResult(
                   (int)Grades.AverageGrade,
                   (int)Grades.MinGrade,
                   (int)Grades.MaxGrade,
                    "Average results: about a half problems are done!");
            }

            if (this.ProblemsSolved >= SimpleMathExam.ProblemsSolvedForPass)
            {
                return new ExamResult(
                    (int)Grades.PassGrade,
                    (int)Grades.MinGrade,
                    (int)Grades.MaxGrade,
                    "Poor results: almost nothing is done!");
            }

            return new ExamResult(
                (int)Grades.MinGrade,
                (int)Grades.MinGrade,
                (int)Grades.MaxGrade,
                "Bad results: nothing done!");
        }
    }
}