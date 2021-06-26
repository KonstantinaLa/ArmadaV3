using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class EmperorConfig : EntityTypeConfiguration<Emperor>
    {
        internal EmperorConfig()
        {
            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Age)
                .IsRequired();

            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}