using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolSystem.Models
{
    public class Homework
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public DateTime SentTime { get; set; }

        [Required]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
