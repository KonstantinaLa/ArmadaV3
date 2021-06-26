using System.Data.Entity.ModelConfiguration;
using ArmadaV3.Entities;

namespace ArmadaV3.Database.EntitiesConfiguration
{
    internal class AdmiralMissionConfig : EntityTypeConfiguration<AdmiralMission>
    {
        public AdmiralMissionConfig()
        {

            //Many to Many Admiral/Mission
            HasKey(am => new { am.AdmiralId, am.MissionId });

            HasRequired(am => am.Admiral)
                .WithMany(a => a.AdmiralMissions)
                .HasForeignKey(am => am.AdmiralId);

            HasRequired(am => am.Mission)
                .WithMany(m => m.AdmiralMissions)
                .HasForeignKey(am => am.MissionId);

            Property(am => am.IsSuccess).IsOptional();

        }
    }
}