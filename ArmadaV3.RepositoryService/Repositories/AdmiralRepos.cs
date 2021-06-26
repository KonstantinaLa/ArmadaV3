using ArmadaV3.Database;
using ArmadaV3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArmadaV3.Repositories.RepositoryService
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
