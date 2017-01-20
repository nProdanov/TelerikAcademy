namespace SoftwareAcademy
{
    using System.Collections.Generic;
    using System.Text;

    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckStringNullOrEmpty(value, "Name");

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("Teacher: Name={0}{1}{2}{3}",
                this.Name,
                this.courses.Count == 0 ? "" : "; Courses=[",
                string.Join(",",
                this.courses),
                this.courses.Count == 0 ? "" : "]"));
            return result.ToString();
        }
    }
}
