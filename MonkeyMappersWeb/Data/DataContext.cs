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
        public DbSet<MathQuestion> Maths { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MathQuestion>().HasOne<Player>(p => p.Player).WithMany().HasForeignKey(p => p.PlayerId);

            // Seeded data
            modelBuilder.Entity<Player>().HasData
            (
                new Player { Id = 1, Name = "Hobbitten", SteamId = "STEAM_0:1:26854395" }, // Hobbitten's SteamID
                new Player { Id = 2, Name = "Random User 1", SteamId = "STEAM_0:1:26853395" },
                new Player { Id = 3, Name = "Random User 2", SteamId = "STEAM_0:1:26854495" }
            );

            modelBuilder.Entity<MathQuestion>().HasData
            (
                new MathQuestion { Id = 1, PlayerId = 1, Question = "5 + 3" },
                new MathQuestion { Id = 2, PlayerId = 1, Question = "10 - 4" },
                new MathQuestion { Id = 3, PlayerId = 2, Question = "7 * 6" }
            );
        }
    }
}
