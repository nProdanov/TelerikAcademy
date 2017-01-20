using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Superhero
    {
        private ICollection<Power> powers;
        private ICollection<Fraction> fractions;

        public Superhero()
        {
            this.powers = new HashSet<Power>();
            this.fractions = new HashSet<Fraction>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(60)]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string SecretIdentity { get; set; } 

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public AlignmentType Alignment { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Story { get; set; }

        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }

        public virtual ICollection<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

    }
}
