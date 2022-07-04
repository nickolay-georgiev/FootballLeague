using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Team;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.CommandHandlers.Delete;
using FootballLeague.Persistence.Commands.Delete.Team;
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
            container.Register<ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult>, DeleteTeamDatabaseCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult>, DeleteTeamDatabaseErrorHandler>(Lifestyle.Scoped);
        }
    }
}
