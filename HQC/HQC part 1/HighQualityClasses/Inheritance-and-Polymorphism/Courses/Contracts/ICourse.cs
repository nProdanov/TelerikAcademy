using System.Collections.Generic;

namespace InheritanceAndPolymorphism.Courses.Contracts
{
    public interface ICourse
    {
        string Name { get; }

        string TeacherName { get; set; }

        ICollection<string> Students { get; set; }

        void AddStudent(string student);

        string ToString();
    }
}
