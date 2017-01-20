namespace Animals
{
    public class Kitten : Cat, ISound
    {
        public Kitten(string name)
            : base(name, Sex.Female)
        {

        }
    }
}
