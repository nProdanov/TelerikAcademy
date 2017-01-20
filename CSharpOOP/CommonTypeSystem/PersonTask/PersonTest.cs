namespace PersonTask
{
    public class PersonTest
    {
        public static void Main()
        {
            var persona = new Person("Ivan Ivanov");
            System.Console.WriteLine(persona);

            persona.Age = 17;
            System.Console.WriteLine(persona);
        }
    }
}
