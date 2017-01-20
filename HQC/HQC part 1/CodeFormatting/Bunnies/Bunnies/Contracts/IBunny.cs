namespace Bunnies.Contracts
{
    using Bunnies.Types;

    public interface IBunny
    {
        int Age { get; set; }

        string Name { get; set; }

        FurType FurType { get; set; }

        void Introduce(IWriter writer);
    }
}
