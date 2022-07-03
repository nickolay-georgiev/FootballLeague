using FootballLeague.IoCContainers.IoCPackages.Repository;
using FootballLeague.IoCContainers.IoCPackages.Team;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;

namespace FootballLeague.IoCContainers.SimpleInjectorBootstraper
{
    public static class IoCContainerBootstrap
    {
        public static void InitializeSimpleInjector(Container container)
        {
            foreach (var package in GetPackages())
            {
                package.RegisterServices(container);
            }
        }

        private static IPackage[] GetPackages()
        {
            return new IPackage[]
            {
                new RepositoryPackage(),
                new TeamPackage(),
            };
        }
    }
}
