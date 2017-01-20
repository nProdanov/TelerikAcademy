using System.Collections.Generic;

using SchoolSystem.Contracts;
using SchoolSystem.Models.SchoolActors;

namespace SchoolSystem.Commands
{
    public class TeacherAddMarkCommand : Command, ICommand
    {
        public TeacherAddMarkCommand()
            : base()
        {
        }

        public override string Execute(IList<string> commandParams)
        {
            var teecherId = int.Parse(commandParams[0]);
            var studentId = int.Parse(commandParams[1]);
            var markValue = float.Parse(commandParams[2]);

            var student = this.Engine.GetStudentById(studentId);
            var teacher = this.Engine.GetTeacherById(teecherId);

            var subject = teacher.Subject;
            var markToAdd = new Mark(subject, markValue);

            teacher.AddMark(student, markToAdd);
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {markValue} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
