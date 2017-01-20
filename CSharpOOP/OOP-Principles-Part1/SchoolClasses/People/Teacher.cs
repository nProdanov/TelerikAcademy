namespace SchoolSsystem
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, INameable, ICommentable
    {
        private List<Discipline> disciplines;

        public Teacher(string firstName, string lastName)
                    : base(firstName, lastName)
        {
            this.disciplines = new List<Discipline>();
        }

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
        }

        public void AddDiscipline(Discipline disc)
        {
            this.disciplines.Add(disc);
        }
    }
}
