using System;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
        
        public int? FriendShipId { get; set; }

        public virtual FriendShip Friendship { get; set; }
    }
}
