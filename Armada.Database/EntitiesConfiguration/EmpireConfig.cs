using System.Data.Entity.ModelConfiguration;
using Armada.Entities;

namespace Armada.Database.EntitiesConfiguration
{
    internal class EmpireConfig : EntityTypeConfiguration<Empire>
    {
        internal EmpireConfig()
        {
            //One to Zero...One Empire/Emperor
            HasOptional(e => e.Emperor)
                .WithRequired(emperor => emperor.Empire);

            Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Trait)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.ControlledSystems)
                .IsRequired();

            Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}