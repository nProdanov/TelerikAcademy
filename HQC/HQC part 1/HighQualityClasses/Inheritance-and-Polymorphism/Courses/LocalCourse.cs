using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Utils;

namespace InheritanceAndPolymorphism.Courses
{
    public class LocalCourse : Course
    {
        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
        }

        public LocalCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public LocalCourse(string name, string teacherName, ICollection<string> students)
            : base(name, teacherName, students)
        {
        }

        public LocalCourse(string name, string teacherName, ICollection<string> students, string lab)
            : base(name, teacherName, students)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }
            set
            {
                Validator.ValidateIfValidString(value, "Lab");
                this.lab = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Lab != null)
            {
                result.AppendFormat(" Lab = {0}; }}", this.Lab);
            }

            return result.ToString();
        }
    }
}
