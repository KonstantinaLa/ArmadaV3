using System.Data.Entity.ModelConfiguration;
using Armada.Entities;

namespace Armada.Database.EntitiesConfiguration
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