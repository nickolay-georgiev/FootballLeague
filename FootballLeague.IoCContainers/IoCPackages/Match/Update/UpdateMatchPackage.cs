using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.CommandHandlers.Update.Match;
using FootballLeague.Persistence.Commands.Update.Match;
using FootballLeague.Services.Implementation.Common.Results.Update;
using FootballLeague.Services.Implementation.Match.Builders;
using FootballLeague.Services.Implementation.Match.CommandHandlers.Update;
using FootballLeague.Services.Implementation.Match.Commands;
using FootballLeague.Services.Implementation.Match.Models.Contexts;
using FootballLeague.Services.Implementation.Match.Validators.Update;
using FootballLeague.Services.Implementation.Match.Validators.Update.Models;
using SimpleInjector;
using System;

namespace FootballLeague.IoCContainers.IoCPackages.Match.Update
{
    internal sealed class UpdateMatchPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandsHandlers(container);
            RegisterPersistenceCommandHandlers(container);
            RegisterValidators(container);
            RegisterBuilders(container);
        }

        private void RegisterBuilders(Container container)
        {
            container.Collection.Append<IBuilder<SportMatch, UpdateMatchContext>, SetSportMatchHomeTeamGoalsBuilder>(Lifestyle.Scoped);
            container.Collection.Append<IBuilder<SportMatch, UpdateMatchContext>, SetSportMatchAwayTeamGoalsBuilder>(Lifestyle.Scoped);
            container.Collection.Append<IBuilder<SportMatch, UpdateMatchContext>, SetSportMatcEndDateBuilder>(Lifestyle.Scoped);
        }

        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<UpdateMatchOnGameEndCommand, UpdateEntityResult>, UpdateMatchOnGameEndCommandHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>, UpdateSportMatchDatabaseCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>, UpdateSportTeamsOnGameEndCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>, UpdateSportMatchDatabaseErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterValidators(Container container)
        {
            container.Register<IValidator<UpdateMatchOnGameEndValidationModel>, OneFailedValidationComposit<UpdateMatchOnGameEndValidationModel>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchOnGameEndValidationModel>, MatchEndDateIsBiggerThanCurrentDateTimeValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchOnGameEndValidationModel>, HomeTeamGoalsCountIsEqualOrBiggerThanZeroValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<UpdateMatchOnGameEndValidationModel>, AwayTeamGoalsCountIsEqualOrBiggerThanZeroValidator>(Lifestyle.Scoped);
        }
    }
}
