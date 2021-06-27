using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class EmperorRepos : Repository<Emperor>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext; }
        }

        public EmperorRepos(ApplicationDbContext context) : base(context)
        {

        }

    }
}