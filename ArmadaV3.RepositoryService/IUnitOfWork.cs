using ArmadaV3.Repositories.RepositoryService;
using System;

namespace ArmadaV3.RepositoryService
{
    public interface IUnitOfWork:IDisposable
    {
        AdmiralRepos Admirals { get; }
        CrewRepos Crew { get; }

        void Save();
    }
    
}