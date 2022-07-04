using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Team;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Common.CommandHandlers.Delete;
using FootballLeague.Persistence.Common.Commands.Delete;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Team.CommandHandlers.Delete;
using FootballLeague.Services.Implementation.Team.Commands.Delete;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Team.Delete
{
    internal sealed class DeleteTeamPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandsHandlers(container);
            RegisterPersistenceCommandHandlers(container);
        }

        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteEntityByIdResult<SportTeam>>, DeleteTeamByIdCommandHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportTeam>, IResult>, DeleteEntityByIdDatabaseCommandHandler<SportTeam>>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportTeam>, IResult>, DeleteEntityByIntIdDatabaseErrorHandler<SportTeam>>(Lifestyle.Scoped);
        }
    }
}
