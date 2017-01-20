using System;
using System.Collections.Generic;
using System.Linq;

using SchoolSystem.Commands;
using SchoolSystem.Contracts;
using SchoolSystem.Contracts.SchoolActors;

namespace SchoolSystem.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private ILogger logger;

        private Dictionary<int, ITeacher> teachers;
        private Dictionary<int, IStudent> students;

        private Command createTeacher;
        private Command createStudent;
        private Command removeTeacher;
        private Command removeStudent;
        private Command listStudentMarks;
        private Command teacherAddMarkToStudent;

        public Engine(
            IReader reader,
            ILogger logger,
            Command createTeacher,
            Command createStudent,
            Command removeTeacher,
            Command removeStudent,
            Command listStudentMarks,
            Command teacherAddMarkToStudent)
        {
            this.reader = reader;
            this.logger = logger;

            this.students = new Dictionary<int, IStudent>();
            this.teachers = new Dictionary<int, ITeacher>();

            this.createTeacher = createTeacher;
            this.createTeacher.Engine = this;

            this.createStudent = createStudent;
            this.createStudent.Engine = this;

            this.removeTeacher = removeTeacher;
            this.removeTeacher.Engine = this;

            this.removeStudent = removeStudent;
            this.removeStudent.Engine = this;

            this.listStudentMarks = listStudentMarks;
            this.listStudentMarks.Engine = this;

            this.teacherAddMarkToStudent = teacherAddMarkToStudent;
            this.teacherAddMarkToStudent.Engine = this;
        }

        public ITeacher GetTeacherById(int teacherId)
        {
            return this.teachers[teacherId];
        }

        public void AddTeacher(int teacherId, ITeacher teacher)
        {
            this.teachers.Add(teacherId, teacher);
        }

        public void RemoveTeacherById(int teacherId)
        {
            this.teachers.Remove(teacherId);
        }

        public IStudent GetStudentById(int studentId)
        {
            return this.students[studentId];
        }

        public void AddStudent(int studentId, IStudent student)
        {
            this.students.Add(studentId, student);
        }

        public void RemoveStudentById(int studentId)
        {
            this.students.Remove(studentId);
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var input = this.reader.ReadLine();
                    if (input == "End")
                    {
                        break;
                    }

                    var commandParams = input.Split(' ').ToList();

                    var commandName = commandParams.First();
                    commandParams.RemoveAt(0);

                    string commandResult;
                    if (commandName == "CreateStudent")
                    {
                        commandResult = this.createStudent.Execute(commandParams);
                    }
                    else if (commandName == "RemoveStudent")
                    {
                        commandResult = this.removeStudent.Execute(commandParams);
                    }
                    else if (commandName == "StudentListMarks")
                    {
                        commandResult = this.listStudentMarks.Execute(commandParams);
                    }
                    else if (commandName == "CreateTeacher")
                    {
                        commandResult = this.createTeacher.Execute(commandParams);
                    }
                    else if (commandName == "TeacherAddMark")
                    {
                        commandResult = this.teacherAddMarkToStudent.Execute(commandParams);
                    }
                    else if (commandName == "RemoveTeacher")
                    {
                        commandResult = this.removeTeacher.Execute(commandParams);
                    }
                    else
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    this.logger.Log(commandResult);
                }
                catch (Exception ex)
                {
                    this.logger.Log(ex.Message);
                }
            }
        }
    }
}
