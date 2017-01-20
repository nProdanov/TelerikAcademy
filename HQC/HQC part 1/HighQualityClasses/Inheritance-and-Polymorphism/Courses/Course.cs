using System.Collections.Generic;
using System.Text;

using InheritanceAndPolymorphism.Courses.Contracts;
using InheritanceAndPolymorphism.Utils;

namespace InheritanceAndPolymorphism.Courses
{
    public class Course : ICourse
    {
        protected string name;
        protected string teacherName;
        protected ICollection<string> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<string>();
        }

        public Course(string name, string teacherName)
            : this(name)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, ICollection<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                Validator.ValidateIfValidString(value, "Coursename");
                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }
            set
            {
                Validator.ValidateIfValidString(value, "Teachername");
                this.teacherName = value;
            }
        }

        public ICollection<string> Students
        {
            get
            {
                var studentsToShow = new List<string>(this.students);
                return studentsToShow;
            }
            set
            {
                Validator.ValidateIfValidCollection(value, "Students");
                foreach (var stud in value)
                {
                    Validator.ValidateIfValidString(stud, "Student");
                    this.students.Add(stud);
                }
            }
        }

        public void AddStudent(string student)
        {
            Validator.ValidateIfValidString(student, "Student");
            this.students.Add(student);
        }

        public override string ToString()
        {
            var teacherStr = this.teacherName != null ? string.Format("Teacher = {0}; ", this.teacherName) : string.Empty;

            StringBuilder result = new StringBuilder();
            result.AppendFormat(
                "{0} {{ Name = {1}; {2}Students = {3};",
                this.GetType().Name,
                this.Name,
                teacherStr,
                this.GetStudentsAsString());

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            return string.Format("{{ {0} }}", string.Join(", ", this.students));
        }
    }
}
