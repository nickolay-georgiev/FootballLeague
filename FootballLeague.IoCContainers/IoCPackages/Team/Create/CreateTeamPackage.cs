using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.CommandHandlers.Add.Team;
using FootballLeague.Persistence.Commands.Add.Team;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.QueryHandlers.GetByName.Team;
using FootballLeague.Persistence.Result.Add.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using FootballLeague.Services.Implementation.ErrorHandlers;
using FootballLeague.Services.Implementation.Team.CommandHandlers.Create;
using FootballLeague.Services.Implementation.Team.Commands.Create;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using FootballLeague.Services.Implementation.Team.Validators.Create;
using FootballLeague.Services.Implementation.Team.Validators.Create.Models;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Team.Create
{
    internal class CreateTeamPackage : IPackage
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
            container.Register<IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>, TeamByNameDatabaseQueryHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IQueryHandler<TeamByNameDatabaseQuery, TeamByNameDatabaseResult>, TeamByNameErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult>, AddSportTeamToDatabaseCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult>, AddSportTeamToDatabaseErrorHandler>(Lifestyle.Scoped);
        }


        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult>, CreateTeamcCommandErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterValidators(Container container)
        {
            container.Register<IValidator<CreateTeamValidationModel>, OneFailedValidationComposit<CreateTeamValidationModel>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, TeamNameIsNotNullOrEmptyValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, TeamWithSelectedNameDoesNotExistValidator>(Lifestyle.Scoped);
        }
    }
}
