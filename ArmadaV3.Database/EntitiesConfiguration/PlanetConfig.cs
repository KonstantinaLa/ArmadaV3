using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class PlanetConfig : EntityTypeConfiguration<Planet>
    {
        internal PlanetConfig()
        {
            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.StarSystem)
                .IsRequired()
                .HasMaxLength(50);

            Property(p => p.Type)
                .IsRequired();

        }
    }
}
