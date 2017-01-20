using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;

using SocialNetwork.Models;

namespace SocialNetwork.Data
{
    public class SocialNetworkDbContext : DbContext
    {
        public SocialNetworkDbContext()
                :base("SocialNetworkDb")
        {

        }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Post> Posts { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<FriendShip> FriendShips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(u => u.Username)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName, 
                    new IndexAnnotation(new IndexAttribute("IX_UName", 1) { IsUnique = true }));

            modelBuilder
                .Entity<Message>()
                .Property(m => m.SentOn)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_SentOn", 1) { IsUnique = false }));

            modelBuilder
                .Entity<FriendShip>()
                .Property(f => f.Approved)
                .HasColumnAnnotation(
                    IndexAnnotation.AnnotationName,
                    new IndexAnnotation(new IndexAttribute("IX_Approved", 1) { IsUnique = false }));


            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
