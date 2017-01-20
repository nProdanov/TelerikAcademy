namespace Animals
{
    public class Dog : Animal, ISound
    {
        public Dog(string name, Sex sex)
            : base(name, sex)
        {
        }

        public override void GrowUp()
        {
            this.age += 7;
        }

        public override string MakeSound()
        {
            return "Bark-bark-Bark";
        }
    }
}
