using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class AdmiralConfig : EntityTypeConfiguration<Admiral>
    {
        internal AdmiralConfig()
        {
            //One to Many Admiral/Empire
            HasOptional(a => a.Empire)
                .WithMany(e => e.Admirals)
                .HasForeignKey<int?>(a => a.EmpireId);

            //One to One Admiral/Crew
            HasRequired(a => a.Crew)
                .WithRequiredPrincipal(c => c.Admiral);

            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Age)
                .IsRequired();

            Property(a => a.EnlistmentDate).IsRequired().HasColumnType("Date");

            Property(a => a.Description).IsRequired().HasMaxLength(1000);
        }
    }
}