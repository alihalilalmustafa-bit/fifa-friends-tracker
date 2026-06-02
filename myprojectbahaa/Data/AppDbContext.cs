using Microsoft.EntityFrameworkCore;
using myprojectbahaa.Models;

namespace myprojectbahaa.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1, Name = "Ahmed Al-Rashid", Username = "AhmedR", Wins = 12, Losses = 3, Draws = 2, GoalsScored = 38, GoalsConceded = 18 },
                new Player { Id = 2, Name = "Omar Khalid", Username = "OmarK", Wins = 9, Losses = 6, Draws = 2, GoalsScored = 29, GoalsConceded = 24 },
                new Player { Id = 3, Name = "Yusuf Demir", Username = "YusufD", Wins = 7, Losses = 7, Draws = 3, GoalsScored = 25, GoalsConceded = 27 },
                new Player { Id = 4, Name = "Tariq Hassan", Username = "TariqH", Wins = 5, Losses = 10, Draws = 2, GoalsScored = 19, GoalsConceded = 33 },
                new Player { Id = 5, Name = "Bilal Sahin", Username = "BilalS", Wins = 4, Losses = 11, Draws = 2, GoalsScored = 15, GoalsConceded = 36 }
            );

            modelBuilder.Entity<Match>().HasData(
                new Match { Id = 1, Player1Id = 1, Player2Id = 2, Score1 = 3, Score2 = 1, Date = new DateTime(2026, 5, 1) },
                new Match { Id = 2, Player1Id = 1, Player2Id = 3, Score1 = 2, Score2 = 0, Date = new DateTime(2026, 5, 2) },
                new Match { Id = 3, Player1Id = 2, Player2Id = 4, Score1 = 4, Score2 = 2, Date = new DateTime(2026, 5, 3) },
                new Match { Id = 4, Player1Id = 3, Player2Id = 5, Score1 = 1, Score2 = 1, Date = new DateTime(2026, 5, 4) },
                new Match { Id = 5, Player1Id = 1, Player2Id = 4, Score1 = 5, Score2 = 0, Date = new DateTime(2026, 5, 5) },
                new Match { Id = 6, Player1Id = 2, Player2Id = 5, Score1 = 3, Score2 = 2, Date = new DateTime(2026, 5, 6) },
                new Match { Id = 7, Player1Id = 3, Player2Id = 4, Score1 = 2, Score2 = 1, Date = new DateTime(2026, 5, 7) },
                new Match { Id = 8, Player1Id = 1, Player2Id = 5, Score1 = 4, Score2 = 1, Date = new DateTime(2026, 5, 8) }
            );
        }
    }
}