using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class MissionConfig : EntityTypeConfiguration<Mission>
    {
        internal MissionConfig()
        {
            //Planets/Missions Many to Many
            HasMany(m => m.Planets)
                .WithMany(p => p.Missions)
                .Map(map =>
                {
                    map.ToTable("PlanetsMissions");
                    map.MapLeftKey("MissionId");
                    map.MapRightKey("PlanetId");
                });

            //Properties
            Property(m => m.Type)
                .IsRequired()
                .HasMaxLength(50);

            Property(m => m.StartDate)
                .IsRequired()
                .HasColumnType("Date");

            Property(m => m.EndDate)
                .IsRequired()
                .HasColumnType("Date");
        }
    }
}