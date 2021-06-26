using ArmadaV3.Database;
using ArmadaV3.Repositories.RepositoryService;
using System;

namespace ArmadaV3.RepositoryService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public AdmiralRepos Admirals { get; }
        public CrewRepos Crew { get; }
        public UnitOfWork()
        {
            context = new ApplicationDbContext();

            Admirals = new AdmiralRepos(context);

            Crew = new CrewRepos(context);

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
