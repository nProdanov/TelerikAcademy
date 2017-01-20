namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;

    public class Goblin : Creature
    {
        private const int AttackPoints = 4;
        private const int DefensePoints = 2;
        private const int Health = 5;
        private const decimal DamagePoints = 1.5m;

        public Goblin()
            : base(Goblin.AttackPoints, Goblin.DefensePoints, Goblin.Health, Goblin.DamagePoints)
        {
        }
    }
}
