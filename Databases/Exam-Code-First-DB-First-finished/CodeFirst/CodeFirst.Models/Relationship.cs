using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Relationship
    {
        public int Id { get; set; }

        [Required]
        public int FirstSuperheroId { get; set; }

        public virtual Superhero FirstSuperhero { get; set; }

        [Required]
        public int SecondSuperheroId { get; set; }

        public virtual Superhero SecondSuperhero { get; set; }

        public RelationType Relation { get; set; }
    }
}
