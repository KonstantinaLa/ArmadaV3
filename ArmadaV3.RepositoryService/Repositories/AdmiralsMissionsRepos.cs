using ArmadaV3.Database;
using ArmadaV3.Entities;


namespace ArmadaV3.RepositoryService.Repositories
{
     public class AdmiralsMissionsRepos : Repository<AdmiralMission>
     {
         public ApplicationDbContext DbContext
         {
             get { return Context as ApplicationDbContext; }
         }
     
     
         public AdmiralsMissionsRepos(ApplicationDbContext context) : base(context)
         {
     
         }
     }
}
