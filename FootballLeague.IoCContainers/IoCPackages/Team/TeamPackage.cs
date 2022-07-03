using FootballLeague.IoCContainers.IoCPackages.Team.Create;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;
namespace FootballLeague.IoCContainers.IoCPackages.Team
{
    public class TeamPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            foreach (var package in GetPackages())
            {
                package.RegisterServices(container);
            }
        }

        private IPackage[] GetPackages()
        {
            return new IPackage[]
            {
                new CreateTeamPackage(),
            };
        }
    }
}
