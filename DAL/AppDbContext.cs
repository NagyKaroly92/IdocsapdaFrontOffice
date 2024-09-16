using DAL.DbSets;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Room> Room { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<GamePlayerDetails2> GamePlayerDetails2 { get; set; }
        public DbSet<EnglishGamePlayerDetails> EnglishGamePlayerDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=192.168.2.11;Port=3306;Database=idocsapda;User=Idocsapda;Password=icstestuser;",
            //optionsBuilder.UseMySql("Server=kahome.zapto.org;Port=19202;Database=idocsapda;User=Idocsapda;Password=icstestuser;",
                new MySqlServerVersion(new Version(10, 5, 9)));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GamePlayerDetails2>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("gameplayerdetails2");
            }).Entity<EnglishGamePlayerDetails>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("englishgameplayerdetails");
            });
        }
    }
}
