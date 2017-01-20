namespace People
{
    public class Person
    {
        public Person(int age)
        {
            this.Age = age;
        }

        public Gender Gender { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }
    }
}
