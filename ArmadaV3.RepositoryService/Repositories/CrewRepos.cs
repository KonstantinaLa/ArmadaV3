using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class CrewRepos:Repository<Crew>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext; }
        }


        public CrewRepos(ApplicationDbContext context):base(context)
        {

        }

    }
}
