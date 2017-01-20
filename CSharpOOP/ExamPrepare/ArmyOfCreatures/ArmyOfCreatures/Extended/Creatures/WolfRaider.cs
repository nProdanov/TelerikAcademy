namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Specialties;

    public class WolfRaider : Creature
    {
        private const int AttackPoints = 8;
        private const int DefensePoints = 5;
        private const int Health = 10;
        private const decimal DamagePoints = 3.5m;
        private const int DoubleDamageRounds = 7;

        public WolfRaider() 
            : base(WolfRaider.AttackPoints, WolfRaider.DefensePoints, WolfRaider.Health, WolfRaider.DamagePoints)
        {
            this.AddSpecialty(new DoubleDamage(WolfRaider.DoubleDamageRounds));
        }
    }
}
