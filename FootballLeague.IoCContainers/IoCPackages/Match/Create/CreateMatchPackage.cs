using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.CommandHandlers.Add.Match;
using FootballLeague.Persistence.CommandHandlers.Add.Team;
using FootballLeague.Persistence.Commands.Add.Match;
using FootballLeague.Services.Implementation.Match.CommandHandlers.Create;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Models.Result.Create;
using FootballLeague.Services.Implementation.Match.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Match.Create
{
    internal sealed class CreateMatchPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterPersistenceQueryHandlers(container);
            RegisterPersistenceCommandHandlers(container);
            RegisterCommandsHandlers(container);
            RegisterValidators(container);
        }

        private void RegisterPersistenceQueryHandlers(Container container)
        {
            //container.Register<IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>, TeamByNameDatabaseQueryHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>, TeamByNameErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>, AddSportMatchToDatabaseCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>, AddSportTeamToDatabaseErrorHandler>(Lifestyle.Scoped);
        }


        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>, CreateMatchCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamcCommandErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterValidators(Container container)
        {
            container.Register<IValidator<CreateTeamValidationModel>, OneFailedValidationComposit<CreateTeamValidationModel>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, MatchStartDateValidator>(Lifestyle.Scoped);
            //container.Collection.Append<IValidator<CreateTeamValidationModel>, TeamWithSelectedNameDoesNotExistValidator>(Lifestyle.Scoped);
        }
    }
}
