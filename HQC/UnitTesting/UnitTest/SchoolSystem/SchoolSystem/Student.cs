namespace SchoolSystem
{
    public class Student
    {
        private string name;

        public Student(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                Validator.ValidateName(value);

                this.name = value;
            }
        }
    }
}
