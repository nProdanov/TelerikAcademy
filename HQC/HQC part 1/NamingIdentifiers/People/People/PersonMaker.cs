namespace People
{
    public class PersonMaker
    {
        public void Make(int age)
        {
            var person = new Person();
            person.Age = age;

            if (age % 2 == 0)
            {
                person.Name = "Dude";
                person.gender = Gender.Male;
            }
            else
            {
                person.Name = "FemaleDude";
                person.gender = Gender.Female;
            }
        }
    }
}
