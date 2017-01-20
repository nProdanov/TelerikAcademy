namespace ArmyOfCreatures.Extended.Creatures
{
    using Logic.Creatures;
    using Logic.Specialties;
    using Specialties;

    public class CyclopsKing : Creature
    {
        //        Add class CyclopsKing. The CyclopsKing is a creature with attack 17, defense 13, damage 18, health points 70 and the following specialties:
        //AddAttackWhenSkip with 3 attack points for each skip action.
        //DoubleAttackWhenAttacking for 4 rounds
        //DoubleDamage for 1 round
        private const int AttackPoints = 17;
        private const int DefensePoints = 13;
        private const int Health = 70;
        private const decimal DamagePoints = 18m;
        private const int AttackPointsToAddWhenSkip = 3;
        private const int DoubleAttacRoundskWhenAttacking = 4;
        private const int DoubleDamageRounds = 1;


        public CyclopsKing()
            : base(CyclopsKing.AttackPoints, CyclopsKing.DefensePoints, CyclopsKing.Health, CyclopsKing.DamagePoints)
        {
            this.AddSpecialty(new AddAttackWhenSkip(CyclopsKing.AttackPointsToAddWhenSkip));
            this.AddSpecialty(new DoubleAttackWhenAttacking(CyclopsKing.DoubleAttacRoundskWhenAttacking));
            this.AddSpecialty(new DoubleDamage(CyclopsKing.DoubleDamageRounds));
        }
    }
}
