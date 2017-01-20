using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;

using CodeFirst.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CodeFirst.EfData
{
    public class EfDbContext : DbContext
    {
        public EfDbContext()
            : base("SuperheroesDB") 
        {

        }
        
        public virtual IDbSet<Superhero> Superheroes { get; set; }

        public virtual IDbSet<Power> Powers { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<Relationship> Relationships { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
               .Entity<Fraction>()
               .Property(f => f.Name)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder
               .Entity<City>()
               .Property(c => c.Name)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder
               .Entity<Country>()
               .Property(c => c.Name)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder
               .Entity<Planet>()
               .Property(p => p.Name)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder
               .Entity<Power>()
               .Property(p => p.Name)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder
               .Entity<Superhero>()
               .Property(s => s.SecretIdentity)
               .HasColumnAnnotation(
                   IndexAnnotation.AnnotationName,
                   new IndexAnnotation(new IndexAttribute("IX_Name", 1) { IsUnique = true }));

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
