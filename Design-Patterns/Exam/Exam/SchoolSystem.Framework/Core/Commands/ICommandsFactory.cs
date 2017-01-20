using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models.Factories;

namespace SchoolSystem.Framework.Core.Commands
{
    public interface ICommandsFactory
    {
        ICommand GetCreateStudentCommand(IStudentsFactory studentsFactory);

        ICommand GetCreateTeacherCommand(ITeachersFactory teachersFactory, IMarksFactory marksFactory);

        ICommand GetRemoveStudentCommand();

        ICommand GetRemoveTeacherCommand();

        ICommand GetStudentListMarksCommand();

        ICommand GetTeacherAddMarkCommand();
    }
}
