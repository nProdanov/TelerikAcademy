namespace WarMachines.Machines
{
    using System.Text;

    using Interfaces;

    class Tank : Machine, ITank, IMachine
    {
        private const double InitialHealthPoints = 100;
        private const double DeltaAttackPoints = 40;
        private const double DeltaDefensePoints = 30;
        private bool defenseMode;

        public Tank(string name, double attack, double defense)
            : base(name, attack, defense)
        {
            this.HealthPoints = 100;
            this.defenseMode = true;
            this.AttackPoints -= DeltaAttackPoints;
            this.DefensePoints += DeltaDefensePoints;
        }

        public bool DefenseMode
        {
            get
            {
                return this.defenseMode;
            }
        }

        public void ToggleDefenseMode()
        {
            if (DefenseMode)
            {
                this.defenseMode = false;
                this.AttackPoints += DeltaAttackPoints;
                this.DefensePoints -= DeltaDefensePoints;
            }
            else
            {
                this.defenseMode = true;
                this.AttackPoints -= DeltaAttackPoints;
                this.DefensePoints += DeltaDefensePoints;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
           result.Append(base.ToString());
            result.Append(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return result.ToString();
            
        }
    }
}
