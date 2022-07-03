using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.CommandHandlers.Add.Match;
using FootballLeague.Persistence.Commands.Add.Match;
using FootballLeague.Services.Implementation.Match.Builders;
using FootballLeague.Services.Implementation.Match.CommandHandlers.Create;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Models.Contexts;
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
            RegisterPersistenceCommandHandlers(container);
            RegisterCommandsHandlers(container);
            RegisterValidators(container);
            RegisterDomainModelBuilder(container);
        }
        private void RegisterCommandsHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>, CreateMatchCommandHandler>(Lifestyle.Scoped);
        }

        private void RegisterDomainModelBuilder(Container container)
        {
            container.Register<IDomainEntityBuilder<SportMatch, CreateMatchBuildContext>, MatchDomainModelBuilder>(Lifestyle.Scoped);
            container.Collection.Append<IBuilder<SportMatch, CreateMatchBuildContext>, SportMatchNameBuilder>(Lifestyle.Scoped);
            container.Collection.Append<IBuilder<SportMatch, CreateMatchBuildContext>, SetSportMatchAwayTeamIdBuilder>(Lifestyle.Scoped);
            container.Collection.Append<IBuilder<SportMatch, CreateMatchBuildContext>, SetSportMatchHomeTeamIdBuilder>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            container.Register<ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>, AddSportMatchToDatabaseCommandHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>, AddSportMatchToDatabaseErrorHandler>(Lifestyle.Scoped);
        }

        private void RegisterValidators(Container container)
        {
            container.Register<IValidator<CreateTeamValidationModel>, OneFailedValidationComposit<CreateTeamValidationModel>>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, MatchStartDateValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, HomeTeamIsNotNullValidator>(Lifestyle.Scoped);
            container.Collection.Append<IValidator<CreateTeamValidationModel>, AwayTeamIsNotNullValidator>(Lifestyle.Scoped);
        }
    }
}
