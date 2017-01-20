namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class AncientBehemoth : Creature
    {
        private const int AttackPoints = 19;
        private const int DefensePoints = 19;
        private const int Health = 300;
        private const decimal DamagePoints = 40;
        private const int ReduceEnemyDefenseValueInPercentages = 80;
        private const int RoundsForDoubleDefenseWhenDefensing = 5;

        public AncientBehemoth()
            : base(AncientBehemoth.AttackPoints, AncientBehemoth.DefensePoints, AncientBehemoth.Health, AncientBehemoth.DamagePoints)
        {
            this.AddSpecialty(new ReduceEnemyDefenseByPercentage(AncientBehemoth.ReduceEnemyDefenseValueInPercentages));
            this.AddSpecialty(new DoubleDefenseWhenDefending(AncientBehemoth.RoundsForDoubleDefenseWhenDefensing));
        }
    }
}
