using System.Data.Entity.ModelConfiguration;
using Armada.Entities;

namespace Armada.Database.EntitiesConfiguration
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