namespace WarMachines.Machines
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;

    class Pilot : IPilot
    {
        private string name;
        private ICollection<IMachine> machines;


        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                Validator.CheckName(value, "name");

                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            this.machines.Add(machine);
        }

        public string Report()
        {
            var result = new StringBuilder();
            result.Append(string.Format("{0} - {1} {2}",
                this.Name,
                this.machines.Count == 0 ? "no" : this.machines.Count.ToString(),
                this.machines.Count == 1 ? "machine" : "machines"));
            var sorted = this.machines
                 .OrderBy(m => m.HealthPoints)
                 .ThenBy(m => m.Name);
            foreach(var m in sorted)
            {
                result.AppendLine();
                result.Append(m.ToString());
            }

            return result.ToString();

            
        }
    }
}
