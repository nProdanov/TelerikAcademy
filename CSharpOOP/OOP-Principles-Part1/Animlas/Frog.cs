namespace Animals
{
    public class Frog : Animal, ISound
    {
        public Frog(string name, Sex sex)
            : base(name, sex)
        {
        }

        public override void GrowUp()
        {
            this.age += 6;
        }

        public override string MakeSound()
        {
            return "Frog-frog";
        }
    }
}
