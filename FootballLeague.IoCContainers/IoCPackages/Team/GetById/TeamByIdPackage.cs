using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.QueryHandlers.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using FootballLeague.Services.Implementation.Team.Models.Result.GetByUd.Team;
using FootballLeague.Services.Implementation.Team.Queries.GetById.Team;
using FootballLeague.Services.Implementation.Team.QueryHandlers.GetById.Team;
using FootballLeague.Services.Implementation.Team.Validators.GetById;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Team.GetById
{
    public sealed class TeamByIdPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterQueryHandlers(container);
            RegisterPersistenceHandlers(container);
            RegisterValidators(container);
        }

        private void RegisterQueryHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<TeamByIdQuery, TeamByIdResult>, TeamByIdQueryHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceHandlers(Container container)
        {
            container.Register<IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult>, TeamByIdDatabaseQueryHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult>, TeamByIdDatabaseErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterValidators(Container container)
        {
            container.Register<IValidator<int>, TemaIdIsBiggerThanZero>(Lifestyle.Singleton);
        }
    }
}
