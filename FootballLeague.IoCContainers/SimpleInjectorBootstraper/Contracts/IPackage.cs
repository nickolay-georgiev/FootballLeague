using SimpleInjector;

namespace FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts
{
    public interface IPackage
    {
        public void RegisterServices(Container container);
    }
}
