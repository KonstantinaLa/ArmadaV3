using System.Linq;
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

        public bool Exists(int id)
        {
            return DbContext.Emperors.Count(e => e.EmperorId == id) > 0;
        }
    }
}