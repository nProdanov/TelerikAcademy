namespace StudentsAndWorkers
{
    using System;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        public Human()
        {

        }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public virtual string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                CheckName(value);
                this.lastName = value;
            }
        }

        public virtual string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                CheckName(value);
                this.firstName = value;
            }
        }

        protected void CheckName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name is empty!");
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
    }
}
