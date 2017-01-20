using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImgUrl { get; set; }

        [Required]
        [MaxLength(4)]
        public string FileExtension { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
