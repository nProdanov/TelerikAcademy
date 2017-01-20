namespace SchoolSystem
{
    public class SchoolStudent : Student
    {
        private int uniqueNumber;

        public SchoolStudent(string name, int uniqueNumber)
            : base(name)
        {
            this.UniqueNumber = uniqueNumber;
        }

        public int UniqueNumber
        {
            get
            {
                return this.uniqueNumber;
            }
            private set
            {
                this.uniqueNumber = value;
            }
        }
    }
}
