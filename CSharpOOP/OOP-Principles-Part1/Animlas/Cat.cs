namespace Animals
{
    public abstract class Cat : Animal, ISound
    {
        public Cat(string name, Sex sex)
            : base(name, sex)
        {
        }

        public override void GrowUp()
        {
            this.age += 6;
        }

        public override string MakeSound()
        {
           return "Mew-Mew";
        }
    }
}
