namespace SchoolSystem
{
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {
        private int nextUniqueNumber = 10000;
        private ICollection<Course> courses;
        private string name;

        public School(string name)
        {
            this.Name = name;
            this.courses = new List<Course>();
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

        public IEnumerable<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddCourse(Course courseToAdd)
        {
            Validator.ValidateObjectNotNull(courseToAdd, "course");

            this.courses.Add(courseToAdd);
        }

        public void RemoveCourse(Course courseToRemove)
        {
            Validator.ValidateObjectNotNull(courses, "course");

            this.courses.Remove(courseToRemove);
        }

        public void AddStudentToCourse(Course courseToAddStudent, SchoolStudent studentToAdd)
        {
            Validator.ValidateObjectNotNull(courseToAddStudent, "course");

            if (this.Courses.Any(c => c.Equals(courseToAddStudent)))
            {
                courseToAddStudent.AddStudent(studentToAdd);
            }
            
        }

        public void RemoveStudentFromCourse(Course courseToRemoveStudent, SchoolStudent studentToRemove)
        {
            Validator.ValidateObjectNotNull(courseToRemoveStudent, "course");
            
            if (this.Courses.Any(c => c.Equals(courseToRemoveStudent)))
            {
                courseToRemoveStudent.RemoveStudent(studentToRemove);
            }
            
        }

        public int GenerateUniqueNumbers()
        {
            Validator.ValidateUniqueNumberIsUnderMinUniqueValue(this.nextUniqueNumber);
            Validator.ValidateSchoolCapacity(this.nextUniqueNumber);

            int currUniqueNumber = this.nextUniqueNumber;

            nextUniqueNumber++;

            return currUniqueNumber;
        }

        public SchoolStudent CreateSchoolStudent(string name)
        {
            var studentUniqueNumber = this.GenerateUniqueNumbers();

            return new SchoolStudent(name, studentUniqueNumber);
        }
    }
}
