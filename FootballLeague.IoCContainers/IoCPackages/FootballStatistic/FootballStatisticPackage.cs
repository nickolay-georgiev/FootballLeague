using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Persistence.Queries.FootballStatistic.Get;
using FootballLeague.Persistence.QueryHandlers.FootballStatistic.Get;
using FootballLeague.Persistence.Result.FootballStatistic.Get;
using FootballLeague.Services.Implementation.FootballStatistic.Queries;
using FootballLeague.Services.Implementation.FootballStatistic.QueryHandlers;
using FootballLeague.Services.Implementation.FootballStatistic.Result;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.SportStatistic
{
    public sealed class FootballStatisticPackage : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IAsyncQueryHandler<FootballStatisticQuery, FootballStatisticResult>, FootballStatisticQueryHandler>(Lifestyle.Scoped);

            container.Register<IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult>, FinishedFootballStatisticDatabaseQueryHandler>(Lifestyle.Scoped);
            container.RegisterDecorator<IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult>, FinishedFootballStatisticDatabaseErrorHandler>(Lifestyle.Scoped);

        }
    }
}
