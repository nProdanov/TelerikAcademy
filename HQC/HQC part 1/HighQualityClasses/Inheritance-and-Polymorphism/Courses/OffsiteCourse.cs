using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Utils;

namespace InheritanceAndPolymorphism.Courses
{
    public class OffsiteCourse : Course
    {
        private string town;

        public OffsiteCourse(string name)
            : base(name)
        {
        }

        public OffsiteCourse(string name, string teacherName)
            : base(name, teacherName)
        {
        }

        public OffsiteCourse(string name, string teacherName, ICollection<string> students)
            : base(name, teacherName, students)
        {
        }

        public OffsiteCourse(string name, string teacherName, ICollection<string> students, string town)
            : base(name, teacherName, students)
        {
            this.Town = town;
        }

        public string Town
        {
            get
            {
                return this.town;
            }
            set
            {
                Validator.ValidateIfValidString(value, "Town");
                this.town = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());

            if (this.Town != null)
            {
                result.AppendFormat(" Town = {0}; }}", this.Town);
            }

            return result.ToString();
        }
    }
}
