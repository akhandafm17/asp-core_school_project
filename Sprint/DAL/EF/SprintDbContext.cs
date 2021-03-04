
using GP.BL.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Logging;

namespace GP.DAL.EF
{
    public class SprintDbContext : DbContext
    {
        public SprintDbContext()
        {
            //false
            SprintInitializer.Initialize(this,false);
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=SprintDb_EFCodeFirst.db")
                    .UseLoggerFactory(LoggerFactory.Create(b => b.AddDebug()));   
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WerknemerTaak>().Property<int>("werknemerId");
            modelBuilder.Entity<WerknemerTaak>().Property<int>("taakId");
            modelBuilder.Entity<WerknemerTaak>().HasKey("werknemerId", "taakId");
           
        }


        public DbSet<Werknemer> Werknemers { get; set; }
        public DbSet<Taak> Taken { get; set; }
        public DbSet<Werkgever> Werkgevers { get; set; }
        public DbSet<WerknemerTaak> WerknemerTaken { get; set; }
        
    }
}