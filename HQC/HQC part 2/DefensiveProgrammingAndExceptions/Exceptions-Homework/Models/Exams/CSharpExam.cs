using ExceptionsHomework.Models.Exams.Contracts;
using ExceptionsHomework.Utils;

namespace ExceptionsHomework.Models.Exams
{
    public class CSharpExam : IExam
    {
        private const int MinScore = 0;
        private const int MaxScore = 100;

        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            private set
            {
                Validator.ValidateIfNumberInRange(value, CSharpExam.MinScore, CSharpExam.MaxScore, "Score");
                this.score = value;
            }
        }

        public ExamResult Check()
        {
            return new ExamResult(this.Score, CSharpExam.MinScore, CSharpExam.MaxScore, "Exam results calculated by score.");
        }
    }
}