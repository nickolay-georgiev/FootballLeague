using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Services.Implementation.Common.Results.Update;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Match.Update
{
    internal sealed class UpdateMatchPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            RegisterCommandsHandlers(container);
            RegisterPersistenceCommandHandlers(container);
        }

        private void RegisterCommandsHandlers(Container container)
        {
            //container.Register<ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateEntityResult>, UpdateTeamTotalSeasonScoreCommandHandler>(Lifestyle.Scoped);
        }

        private void RegisterPersistenceCommandHandlers(Container container)
        {
            //container.Register<ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>, UpdateSportTeamDatabaseCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>, UpdateSportTeamSeasonTotalScoreCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>, UpdateSportTeamMatchPlayedCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>, UpdateSportTeamWonDrawLostStatisticCommandHandler>(Lifestyle.Scoped);
            //container.RegisterDecorator<ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>, UpdateSportTeamDatabaseErrorHandler>(Lifestyle.Scoped);
        }
    }
}
