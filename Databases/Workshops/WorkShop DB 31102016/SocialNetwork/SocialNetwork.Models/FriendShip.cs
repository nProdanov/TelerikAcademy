using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class FriendShip
    {
        private ICollection<Message> messages;

        public FriendShip()
        {
            this.messages = new HashSet<Message>();
        }
        
        public int FriendOneId { get; set; }

        public virtual User FriendOne { get; set; }
        
        public int? FriendTwoId { get; set; }

        public virtual User FriendTwo { get; set; }

        public int Id { get; set; }

        [Required]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }
            set
            {
                this.messages = value;
            }
        }

    }
}
