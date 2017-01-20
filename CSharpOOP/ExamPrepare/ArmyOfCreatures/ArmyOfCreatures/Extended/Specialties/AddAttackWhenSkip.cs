namespace ArmyOfCreatures.Extended.Specialties
{
    using Logic.Battles;
    using Logic.Specialties;

    public class AddAttackWhenSkip : Specialty
    {
        private const int MinAttackToAdd = 1;
        private const int MaxAttackToAdd = 10;
        private int attackToAdd;

        public AddAttackWhenSkip(int attackToAdd)
        {
            Validator.CheckIfIntegerIsInRange(
                attackToAdd, 
                AddAttackWhenSkip.MaxAttackToAdd, 
                AddAttackWhenSkip.MinAttackToAdd, 
                string.Format("Attack which is added when skip has to be in a range [{0} - {1}]!", AddAttackWhenSkip.MinAttackToAdd, AddAttackWhenSkip.MaxAttackToAdd));

            this.attackToAdd = attackToAdd;
        }

        public override void ApplyOnSkip(ICreaturesInBattle skipCreature)
        {
            Validator.CheckIfNull(skipCreature, "Creature can not be a null!");

            skipCreature.PermanentAttack += this.attackToAdd;
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", base.ToString(), this.attackToAdd);
        }
    }
}
