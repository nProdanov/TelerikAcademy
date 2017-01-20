namespace SoftwareAcademy
{
    using System.Text;
    using System.Collections.Generic;

    public class Course : ICourse
    {
        protected string name;
        protected ITeacher teacher;
        protected ICollection<string> topics;

        public Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new List<string>();
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

        public ITeacher Teacher
        {
            get
            {
                return this.teacher;
            }

            set
            {
                this.teacher = value;
            }
        }

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append(string.Format(": Name={0};{1}{2}{3}{4}{5}{6}{7} ",
                this.Name,
                this.Teacher == null ? "" : " Teacher=",
                this.Teacher == null ? "" : this.Teacher.Name,
                this.Teacher == null ? "" : ";",
                this.topics.Count == 0 ? "" : " Topics=[",
                string.Join(",", this.topics),
                this.topics.Count == 0 ? "" : "]",
                this.topics.Count == 0 ? "" : ";"));
            return result.ToString();
        }
    }
}
