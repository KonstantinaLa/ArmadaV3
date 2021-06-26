using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class CrewConfig : EntityTypeConfiguration<Crew>
    {
        internal CrewConfig()
        {
            //One to One Admiral/Crew
            HasRequired(c => c.Admiral)
                .WithRequiredPrincipal(a => a.Crew);

            Property(c => c.Number)
                .IsRequired();

            Property(c => c.Specialty)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}