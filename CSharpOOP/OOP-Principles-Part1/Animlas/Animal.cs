namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        protected string name;
        protected int age;
        protected Sex sex;

        public Animal(string name, Sex sex)
        {
            this.Name = name;
            this.age = 0;
            this.Sex = sex;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name is empty");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            private set
            {
                this.sex = value;
            }
        }

        public abstract void GrowUp();

        public abstract string MakeSound();

        public static double Average(IEnumerable<Animal> collection)
        {
            return collection.Average(an => an.Age);
        }

        public override string ToString()
        {
            return string.Format("{0}, {2} years old : {1}", this.Name, this.MakeSound(), this.Age);
        }

    }
}
