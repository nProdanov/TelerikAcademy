namespace WarMachines.Machines
{
    using System;
    using System.Text;

    using Interfaces;

    public class Fighter : Machine, IFighter, IMachine
    {
        private const double InitialHealthPoints = 200;
        private bool stealthMode;

        public Fighter(string name, double attack, double defense, bool stealthMode) 
            : base(name, attack, defense)
        {
            this.HealthPoints = InitialHealthPoints;
            this.stealthMode = stealthMode;

        }

        public bool StealthMode
        {
            get
            {
                return this.stealthMode;
            }
        }

        public void ToggleStealthMode()
        {
            this.stealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.Append(base.ToString());
            result.Append(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return result.ToString();
        }
    }
}
