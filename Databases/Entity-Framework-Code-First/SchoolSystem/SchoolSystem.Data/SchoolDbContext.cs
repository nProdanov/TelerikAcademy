using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

using SchoolSystem.Models;

namespace SchoolSystem.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext()
            : base("SchoolSystemDb")
        {
        }

        public virtual IDbSet<Course> Courses { get; set; }

        public virtual IDbSet<Student> Students { get; set; }

        public virtual IDbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Course>().Property(c => c.Name)
                .HasColumnAnnotation(
                IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true}));
            base.OnModelCreating(modelBuilder);
        }
    }
}
