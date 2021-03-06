using ArmadaV3.Database;
using ArmadaV3.Entities;

namespace ArmadaV3.RepositoryService.Repositories
{
    public class PlanetRepos : Repository<Planet>
    {
        public ApplicationDbContext DbContext
        {
            get { return Context as ApplicationDbContext;}
        }

        public PlanetRepos(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}
