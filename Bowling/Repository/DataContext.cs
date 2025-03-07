using Bowling.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace Bowling.Repository
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = ConfigurationManager.ConnectionStrings["BowlingDB"].ConnectionString;
            optionsBuilder.UseSqlServer(connString);
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<MatchPlayer> MatchPlayers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MatchPlayer>()
                .HasKey(mp => new { mp.MatchID, mp.PlayerID });
        }

    }
}
