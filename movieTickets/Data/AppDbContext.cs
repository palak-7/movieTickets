using Microsoft.EntityFrameworkCore;
using movieTickets.Models;

namespace movieTickets.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //defines a composite primary key for the Actor_Movie entity
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new { am.ActorId, am.MovieId });

            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Actor).WithMany(a => a.Actors_Movies).HasForeignKey(am => am.ActorId);
            modelBuilder.Entity<Actor_Movie>().HasOne(am => am.Movie).WithMany(a => a.Actors_Movies).HasForeignKey(am => am.MovieId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
    }
}
