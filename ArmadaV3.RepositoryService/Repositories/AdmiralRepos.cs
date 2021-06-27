using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class AdmiralRepos:Repository<Admiral>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext; }

        }

        public AdmiralRepos(ApplicationDbContext context): base(context)
        {
            
        }
    }
}
