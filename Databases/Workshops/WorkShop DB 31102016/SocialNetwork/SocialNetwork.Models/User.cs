using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class User
    {
        private ICollection<Post> posts;
        private ICollection<Image> images;
        private ICollection<Message> sentMessages;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.images = new HashSet<Image>();
            this.sentMessages = new HashSet<Message>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Username { get; set; }

      
        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        
        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }
        
        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Message> SentMessages
        {
            get { return this.sentMessages; }
            set { this.sentMessages = value; }
        }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }

        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
    }
}
