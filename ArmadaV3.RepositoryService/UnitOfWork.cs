using ArmadaV3.Database;
using ArmadaV3.RepositoryService.Repositories;

namespace ArmadaV3.RepositoryService
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext context;
        public AdmiralRepos Admirals { get; }
        public CrewRepos Crew { get; }
        public EmperorRepos Emperors { get; }
        public EmpireRepos Empires { get; }
        public MissionRepos Missions { get; }
        public PlanetRepos Planets { get; }
        public AdmiralsMissionsRepos AdmiralsMissions { get; }
        public UnitOfWork()
        {
            context = new ApplicationDbContext();
            Admirals = new AdmiralRepos(context);
            Crew = new CrewRepos(context);
            Emperors = new EmperorRepos(context);
            Empires = new EmpireRepos(context);
            Missions = new MissionRepos(context);
            Planets = new PlanetRepos(context);
            AdmiralsMissions = new AdmiralsMissionsRepos(context);
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
