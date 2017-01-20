using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Fraction
    {
        private ICollection<Planet> protectedPlanets;
        private ICollection<Superhero> members;

        public Fraction()
        {
            this.protectedPlanets = new HashSet<Planet>();
            this.members = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; } 

        public AlignmentType Alignment { get; set; }

        public virtual ICollection<Planet> ProtectedPlanets
        {
            get { return this.protectedPlanets; }
            set { this.protectedPlanets = value; }
        }

        public virtual ICollection<Superhero> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
