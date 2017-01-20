using System.Collections.Generic;

using SchoolSystem.Contracts;

namespace SchoolSystem.Commands
{
    public class StudentListMarksCommand : Command,  ICommand
    {
        public StudentListMarksCommand()
            : base()
        {
        }

        public override string Execute(IList<string> commandParams)
        {
            var studentId = int.Parse(commandParams[0]);
            var student = this.Engine.GetStudentById(studentId);

            return student.ListMarks();
        }
    }
}
