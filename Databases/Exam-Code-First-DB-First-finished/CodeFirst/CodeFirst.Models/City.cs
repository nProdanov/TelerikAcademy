using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class City
    {
        private ICollection<Superhero> superheroes;

        public City()
        {
            this.superheroes = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string Name { get; set; } 

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Superhero> Superheroes
        {
            get { return this.superheroes; }
            set { this.superheroes = value; }
        }
    }
}
