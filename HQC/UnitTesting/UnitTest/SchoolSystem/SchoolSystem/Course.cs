namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        private ICollection<SchoolStudent> students;
        private string name;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<SchoolStudent>();
        }

        public IEnumerable<SchoolStudent> Students
        {
            get
            {
                return this.students;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.ValidateName(value);

                this.name = value;
            }
        }

        public void AddStudent(SchoolStudent studentToAdd)
        {
            Validator.ValidateObjectNotNull(studentToAdd, "student");

            Validator.ValidateCourseCapacity(this.students.Count);

            this.students.Add(studentToAdd);
        }

        public void RemoveStudent(SchoolStudent studentToRemove)
        {
            Validator.ValidateObjectNotNull(studentToRemove, "student");

            this.students.Remove(studentToRemove);
        }

        public override bool Equals(object obj)
        {
            var comparedCourse = obj as Course;

            if (this.Name == comparedCourse.Name)
            {
                if (this.Students.SequenceEqual(comparedCourse.Students))
                {
                    return true;
                }
            }

            return false;
        }

        public override int GetHashCode()
        {
            return this.name.GetHashCode() ^ this.students.GetHashCode();
        }
    }
}
