using SchoolSystem.Commands;
using SchoolSystem.Core;
using SchoolSystem.Models;
using SchoolSystem.Models.SchoolActors;

namespace SchoolSystem
{
    public class Startup
    {
        public static void Main()
        {
            var engine = new Engine(new ConsoleReaderProvider(), new ConsoleLoggerProvider(), new CreateTeacherCommand(), new CreateStudentCommand(), new RemoveTeacherCommand(), new RemoveStudentCommand(), new StudentListMarksCommand(), new TeacherAddMarkCommand());
            engine.Start();
        }
    }
}
