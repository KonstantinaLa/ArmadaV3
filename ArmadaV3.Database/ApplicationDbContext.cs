using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using ArmadaV3.Database.EntitiesConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Emperor> Emperors { get; set; }
        public DbSet<Empire> Empires { get; set; }

        public DbSet<Admiral> Admirals { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<AdmiralMission> AdmiralMissions { get; set; }

        public ApplicationDbContext() : base("Armada")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PlanetConfig());
            modelBuilder.Configurations.Add(new MissionConfig());
            modelBuilder.Configurations.Add(new CrewConfig());
            modelBuilder.Configurations.Add(new AdmiralConfig());
            modelBuilder.Configurations.Add(new EmpireConfig());
            modelBuilder.Configurations.Add(new EmperorConfig());
            modelBuilder.Configurations.Add(new AdmiralMissionConfig());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
