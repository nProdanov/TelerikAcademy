namespace SchoolSsystem
{
    public class Student : Person, INameable
    {
        private int classNumber;

        public Student(string firstName, string lastName)
                    : base(firstName, lastName)
        {
        }

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }

            internal set
            {
                this.classNumber = value;
            }
        }
    }
}
