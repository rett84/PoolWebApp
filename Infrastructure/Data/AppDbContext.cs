

using Microsoft.EntityFrameworkCore;

using PoolApp.Domain.Entities;

namespace PoolApp.Infrastructure.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public class UserState()
        {
            public int Userid { get; set; }
        }



        public DbSet<GamesGroups> Games => Set<GamesGroups>();
        public DbSet<UsersGuessGroups> UsersGuess => Set<UsersGuessGroups>();
        public DbSet<Users> UsersInfo => Set<Users>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Games → UsersGuess relationship
            modelBuilder.Entity<GamesGroups>()
                .HasOne(g => g.Usersguess)
                .WithOne() // or .WithMany() if multiple guesses per match
                .HasForeignKey<UsersGuessGroups>(ug => ug.MatchID);

            // Optional: configure Games → Teams relationships
            modelBuilder.Entity<GamesGroups>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamID);

            modelBuilder.Entity<GamesGroups>()
               .HasOne(g => g.AwayTeam)
               .WithMany()
               .HasForeignKey(g => g.AwayTeamID);
        }


    }
}
