using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Match;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.QueryHandlers.Common.GetById;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Match.Queries.GetById;
using FootballLeague.Services.Implementation.Match.QueryHandlers.GetById;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Match.GetById
{
    public class MatchByIdPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterQueryHandlers(container);
            RegisterPersistenceHandlers(container);
        }

        private void RegisterQueryHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<MatchByIdQuery, EntityByIdResult<SportMatch>>, MatchByIdQueryHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>>, EntityByIntIdDatabaseQueryHandler<SportMatch>>(Lifestyle.Scoped);
            container.RegisterDecorator<IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>>, EntityByIntIdDatabaseErrorHandler<SportMatch>>(Lifestyle.Scoped);
        }
    }   
}
