using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Factories
{
    public interface ITeachersFactory
    {
        ITeacher CreateTeaccher(string firstName, string lastName, Subject subject, IMarksFactory marksFactory);
    }
}
