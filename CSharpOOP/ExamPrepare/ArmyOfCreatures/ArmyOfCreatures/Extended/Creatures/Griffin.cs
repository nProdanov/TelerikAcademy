namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;

    public class Griffin : Creature
    {
        private const int AttackPoints = 8;
        private const int DefensePoitns = 8;
        private const int Health = 25;
        private const decimal DamagePoints = 4.5m;
        private const int DoubleDefenseRounds = 5;
        private const int DefensePointsToAddWhenSkip = 3;

        public Griffin()
            : base(Griffin.AttackPoints, Griffin.DefensePoitns, Griffin.Health, Griffin.DamagePoints)
        {
            this.AddSpecialty(new DoubleDefenseWhenDefending(Griffin.DoubleDefenseRounds));
            this.AddSpecialty(new AddDefenseWhenSkip(Griffin.DefensePointsToAddWhenSkip));
            this.AddSpecialty(new Hate(typeof(WolfRaider)));
        }
    }
}
