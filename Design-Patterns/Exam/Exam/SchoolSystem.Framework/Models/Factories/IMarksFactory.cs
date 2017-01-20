using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Models.Factories
{
    public interface IMarksFactory
    {
        IMark CreateMark(Subject subject, float value);
    }
}
