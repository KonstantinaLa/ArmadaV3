using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class MissionRepos : Repository<Mission>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext;}
        }

        public MissionRepos(ApplicationDbContext context):base(context)
        {
            
        }
    }
}
