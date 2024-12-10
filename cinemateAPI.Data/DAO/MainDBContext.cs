using Microsoft.EntityFrameworkCore;
using cinemateAPI.Data.DAO.Entities;

namespace cinemateAPI.Data.DAO
{
    public class MainDBContext : DbContext
    {
        public MainDBContext(DbContextOptions options) : base(options) { }

        public DbSet<MovieEntity> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Create a unique index on the MovieId property
            modelBuilder.Entity<MovieEntity>()
                .HasIndex(m => m.MovieId)
                .IsUnique();  // Set as unique index if needed
        }
    }
}
