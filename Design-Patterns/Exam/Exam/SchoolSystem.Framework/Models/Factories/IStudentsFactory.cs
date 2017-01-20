using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Factories
{
    public interface IStudentsFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);
    }
}
