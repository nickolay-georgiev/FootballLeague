using FootballLeague.IoCContainers.IoCPackages.Common.Validators;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Common
{
    public sealed class CommonPackage : IPackage
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
                new SharedValidators(),
            };
        }
    }
}
