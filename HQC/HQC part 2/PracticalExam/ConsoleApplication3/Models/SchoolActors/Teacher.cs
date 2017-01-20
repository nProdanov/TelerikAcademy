using SchoolSystem.Contracts;
using SchoolSystem.Contracts.SchoolActors;
using SchoolSystem.Types;

namespace SchoolSystem.Models.SchoolActors
{
    public class Teacher : SchoolActor, ITeacher
    {
        public Teacher(string firstName, string lastName, SubjectType subject)
            : base(firstName, lastName)
        {
            this.Subject = subject;
        }

        public SubjectType Subject { get; set; }

        public void AddMark(IStudent student, IMark markToAdd)
        {
            student.GetMark(markToAdd);
        }
    }
}
