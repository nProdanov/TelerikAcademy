namespace Homework.Students
{
    public class Mark
    {
        public Mark(Course course, MarkValue mark)
        {
            this.Course = course;
            this.CourseMark = mark;
        }

        public Course Course { get; set; }

        public MarkValue CourseMark { get; set; }

        public override string ToString()
        {
            return this.Course + " " + this.CourseMark;
        }
    }
}
