namespace PersonTask
{
    using System;
    using System.Text;

    public class Person
    {
        private int? age;
        private string name;

        public Person(string name, int? age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Person(string name)
            : this(name, null)
        {

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name is empty");
                }

                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age can not be a negative number");
                }

                if (value >150)
                {
                    throw new ArgumentOutOfRangeException("Age of the real person ussualy is not more than 150");
                }

                this.age = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(string.Format("Name: {0}", this.Name));
            result.AppendLine();
            result.Append("Age: ");
            if (this.Age == null)
            {
                result.Append("Unknown");
            }
            else
            {
                result.Append(this.Age);
            }

            return result.ToString();
        }
    }
}
