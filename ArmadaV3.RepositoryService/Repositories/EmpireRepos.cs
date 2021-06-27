using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class EmpireRepos : Repository<Empire>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext;}
        }

        public EmpireRepos(ApplicationDbContext context) : base(context)
        {

        }

    }
}
