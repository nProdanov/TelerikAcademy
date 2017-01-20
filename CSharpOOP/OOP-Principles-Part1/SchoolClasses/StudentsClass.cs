namespace SchoolSsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StudentsClass : ICommentable
    {
        private string identifier;
        private List<string> comments;
        private List<Teacher> teachers;
        private List<Student> students;
        private List<Discipline> disciplines;

        public StudentsClass(string id)
        {
            this.comments = new List<string>();
            this.teachers = new List<Teacher>();
            this.students = new List<Student>();
            this.disciplines = new List<Discipline>();
            this.Identifier = id;
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }

        public string Identifier
        {
            get
            {
                return this.identifier;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) 
                {
                    throw new ArgumentNullException("Identifier can not be empty");
                }

                this.identifier = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public List<string> Comments
        {
            get
            {
                return this.comments;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
        }

        public void AddDiscipline(Discipline disc)
        {
            this.disciplines.Add(disc);
        }

        public void AddTeacher(Teacher teacher)
        {
            this.teachers.Add(teacher);
        }

        public void AddStudent(Student student)
        {
            this.students.Add(student);
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public void SetOrderInClass()
        {
            this.students = this.students
                .OrderBy(st => st.FirstName)
                .ThenBy(st => st.LastName)
                .ToList();
            for (int i = 0; i < this.Students.Count; i++)
            {
                this.students[i].ClassNumber = i + 1;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("Students of Class {0}: ", this.Identifier));
            result.AppendLine();
            foreach (var stud in this.Students)
            {
                result.Append(string.Format("Name: {0},\tClass number: {1}", stud.Name, stud.ClassNumber));
                result.AppendLine();
            }

            result.AppendLine();
            foreach (var teacher in this.Teachers)
            {
                if (teacher.LastName.Last() == 'a')
                {
                    result.Append(string.Format("Disciplines of Ms. {0}:", teacher.Name));
                }
                else
                {
                    result.Append(string.Format("Disciplines of Mr. {0}:", teacher.Name));
                }

                result.AppendLine();
                int index = 1;
                foreach (var disc in teacher.Disciplines)
                {
                    result.Append(string.Format("{0}. \"{1}\"", index, disc.Name));
                    result.AppendLine();
                    index++;
                }
            }

            result.AppendLine();
            result.Append("Comments for the class: ");
            result.AppendLine();
            foreach (var comment in this.Comments)
            {
                result.Append(comment);
                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
