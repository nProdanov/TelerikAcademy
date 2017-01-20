using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    public class Power
    {
        private ICollection<Superhero> members;

        public Power()
        {
            this.members = new HashSet<Superhero>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(35)]
        public string Name { get; set; }

        public virtual ICollection<Superhero> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
