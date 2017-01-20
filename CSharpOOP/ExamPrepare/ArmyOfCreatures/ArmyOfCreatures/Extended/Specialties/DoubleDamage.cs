namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using Logic.Battles;
    using Logic.Specialties;

    public class DoubleDamage : Specialty
    {
        private const int MinRounds = 1;
        private const int MaxRounds = 10;
        private const int IncreaserDamage = 2;
        private int rounds;

        public DoubleDamage(int rounds)
        {

            Validator.CheckIfIntegerIsInRange(rounds, 
                DoubleDamage.MaxRounds, 
                DoubleDamage.MinRounds, 
                string.Format("Rounds must be in a range[{0} - {1}]!", DoubleDamage.MinRounds, DoubleDamage.MaxRounds));


            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(
            ICreaturesInBattle attackerWithSpecialty,
            ICreaturesInBattle defender,
            decimal currentDamage)
        {
            Validator.CheckIfNull(attackerWithSpecialty, "creature who attack can not be a null!");
            Validator.CheckIfNull(defender, "defender can not be a null!");

            if (this.rounds <= 0)
            {
                return currentDamage;
            }

            this.rounds--;
            return currentDamage * DoubleDamage.IncreaserDamage;  
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.rounds);
        }




    }
}
