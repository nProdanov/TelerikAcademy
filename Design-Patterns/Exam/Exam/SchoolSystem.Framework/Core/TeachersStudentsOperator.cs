using System;
using System.Collections.Generic;

using SchoolSystem.Framework.Models.Contracts;

namespace SchoolSystem.Framework.Core
{
    public class TeachersStudentsOperator : ITeachersStudentsOperator
    {
        private IDictionary<int, IStudent> students;
        private IDictionary<int, ITeacher> teachers;

        public TeachersStudentsOperator()
        {
            this.students = new Dictionary<int, IStudent>();
            this.teachers = new Dictionary<int, ITeacher>();
        }

        public IStudent GetStudentById(int studentId)
        {
            if (this.students.ContainsKey(studentId))
            {
                return this.students[studentId];
            }
            else
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }
        }

        public ITeacher GetTeacherById(int teacherId)
        {
            if (this.teachers.ContainsKey(teacherId))
            {
                return this.teachers[teacherId];
            }
            else
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }
        }

        public void RemoveTeacher(int teacherId)
        {
            if (this.teachers.ContainsKey(teacherId))
            {
                this.teachers.Remove(teacherId);
            }
            else
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }
        }

        public void AddTeacher(int teacherId, ITeacher teacher)
        {
            this.teachers.Add(teacherId, teacher);
        }

        public void RemoveStudent(int studentId)
        {
            if (this.students.ContainsKey(studentId))
            {
                this.students.Remove(studentId);
            }
            else
            {
                throw new ArgumentException("The given key was not present in the dictionary.");
            }
        }

        public void AddStudent(int studentId, IStudent student)
        {
            this.students.Add(studentId, student);
        }
    }
}
