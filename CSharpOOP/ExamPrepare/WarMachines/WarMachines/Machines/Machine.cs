namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces;
   
    public class Machine : IMachine
    {
        protected string name;
        protected double attackPoints;
        protected double defensePoints;
        protected double healthPoints;
        protected IPilot pilot;
        protected IList<string> targets;
        
        public Machine(string name, double attack, double defense)
        {
            this.Name = name;
            this.AttackPoints = attack;
            this.DefensePoints = defense;
            this.targets = new List<string>();
        } 

        public double AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            protected set
            {
                Validator.CheckForNegative(value, "Attack points");
                Validator.CheckForZero(value, "Attack points");
                this.attackPoints = value;
            }
        }

        public double DefensePoints
        {
            get
            {
                return this.defensePoints;
            }
            protected set
            {
                Validator.CheckForNegative(value, "Defense points");
                Validator.CheckForZero(value, "Defense points");

                this.defensePoints = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {

                this.healthPoints = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                Validator.CheckName(value, "Name");

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                Validator.CheckForNull(value, "The Pilot");

                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
        }

        public void Attack(string target)
        {
            this.targets.Add(target);
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            result.AppendLine(string.Format(" *Targets: {0}", this.Targets.Count!=0?string.Join(", ", this.Targets): "None"));

            return result.ToString();

        }
    }
}
