using Microsoft.EntityFrameworkCore;

namespace Ticketing.Models
{
    public partial class DatabaseContext: DbContext
    {
            
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey("Id");
                entity.ToTable("User");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Username).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
