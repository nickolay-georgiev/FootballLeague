using FootballLeague.IoCContainers.IoCPackages.Match.Create;
using FootballLeague.IoCContainers.IoCPackages.Match.GetById;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Match
{
    internal sealed class MatchPackage : IPackage
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
                new CreateMatchPackage(),
                new MatchByIdPackage(),
            };
        }
    }
}
