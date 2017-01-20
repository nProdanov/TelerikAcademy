namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleAttackWhenAttacking : Specialty
    {
        private const int MinDoubleAttackRounds = 1;
        private const int AttackIncreaser = 2;
        private int rounds;

        public DoubleAttackWhenAttacking(int rounds)
        {
            Validator.CheckIfIntegerIsInRange(
                rounds,
                int.MaxValue,
                DoubleAttackWhenAttacking.MinDoubleAttackRounds, 
                string.Format("Rounds has to be greater than {0}!", DoubleAttackWhenAttacking.MinDoubleAttackRounds));

            this.rounds = rounds;
        }

        public override void ApplyWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender)
        {
            Validator.CheckIfNull(attackerWithSpecialty, "Attacker can not be a null!");
            Validator.CheckIfNull(defender, "Defender can not be a null!");

            if(this.rounds <= 0)
            {
                return;
            }

            attackerWithSpecialty.CurrentAttack = attackerWithSpecialty.CurrentAttack * DoubleAttackWhenAttacking.AttackIncreaser;
            this.rounds--;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.rounds);
        }
    }
}
