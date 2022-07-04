using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Team;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.QueryHandlers.Common.GetById;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Team.Queries.GetById.Team;
using FootballLeague.Services.Implementation.Team.QueryHandlers.GetById.Team;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Team.GetById
{
    internal sealed class TeamByIdPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterQueryHandlers(container);
            RegisterPersistenceHandlers(container);
        }

        private void RegisterQueryHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<TeamByIdQuery, EntityByIdResult<SportTeam>>, TeamByIdQueryHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>>, EntityByIntIdDatabaseQueryHandler<SportTeam>>(Lifestyle.Scoped);
            container.RegisterDecorator<IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportTeam>>, EntityByIdDatabaseResult<SportTeam>>, EntityByIntIdDatabaseErrorHandler<SportTeam>>(Lifestyle.Scoped);
        }
    }
}
