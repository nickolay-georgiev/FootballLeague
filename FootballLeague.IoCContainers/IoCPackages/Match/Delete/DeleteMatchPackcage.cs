﻿using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Match;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Common.CommandHandlers.Delete;
using FootballLeague.Persistence.Common.Commands.Delete;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Match.CommandHandlers.Delete;
using FootballLeague.Services.Implementation.Match.Commands.Delete;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Match.Delete
{
    internal sealed class DeleteMatchPackcage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandsHandlers(container);
            RegisterPersistenceCommandHandlers(container);
        }

        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<DeleteMatchByIdCommand, DeleteEntityByIdResult<SportMatch>>, DeleteMatchByIdCommandHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportMatch>, IResult>, DeleteEntityByIdDatabaseCommandHandler<SportMatch>>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<DeleteEntityByIdDatabaseCommand<SportMatch>, IResult>, DeleteEntityByIntIdDatabaseErrorHandler<SportMatch>>(Lifestyle.Scoped);
        }
    }
}
