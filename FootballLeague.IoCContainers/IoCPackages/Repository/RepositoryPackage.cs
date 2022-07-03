using FootballLeague.Data;
using FootballLeague.Data.Common;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Repositories;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Repository
{
    public sealed class RepositoryPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>), Lifestyle.Scoped);
            container.Register(typeof(IRepository<>), typeof(EfRepository<>), Lifestyle.Scoped);
            container.Register<IDbQueryRunner, DbQueryRunner>(Lifestyle.Scoped);
        }
    }
}
