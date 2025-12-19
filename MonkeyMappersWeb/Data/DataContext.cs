using Microsoft.EntityFrameworkCore;
using MonkeyMappersWeb.Models;
using System.Data.Common;

namespace MonkeyMappersWeb.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Player> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>().ToTable("Players");

            // Seeded data
            modelBuilder.Entity<Player>().HasData
            (
                new Player { Id = 1, Name = "Hobbitten", SteamId = "STEAM_0:1:26854395", DateTime = new DateTime(2025, 12, 18), }, // Hobbitten's SteamID
                new Player { Id = 2, Name = "Random User 1", SteamId = "STEAM_0:1:26853395", DateTime = new DateTime(2025, 12, 10) },
                new Player { Id = 3, Name = "Random User 2", SteamId = "STEAM_0:1:26854495", DateTime = new DateTime(2025, 12, 19) }
            );
        }
    }
}
