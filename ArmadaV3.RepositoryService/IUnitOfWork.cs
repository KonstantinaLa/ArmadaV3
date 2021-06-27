using System;
using ArmadaV3.RepositoryService.Repositories;

namespace ArmadaV3.RepositoryService
{
    public interface IUnitOfWork:IDisposable
    {
        AdmiralRepos Admirals { get; }
        CrewRepos Crew { get; }
        EmperorRepos Emperors { get; }
        EmpireRepos Empires { get; }
        MissionRepos Missions { get; }
        PlanetRepos Planets { get; }

        void Save();
    }
    
}