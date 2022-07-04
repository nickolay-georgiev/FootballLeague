using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Queries.FootballStatistic.Get;
using FootballLeague.Persistence.Result.FootballStatistic.Get;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.QueryHandlers.FootballStatistic.Get
{
    public sealed class FinishedFootballStatisticDatabaseErrorHandler : IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult>
    {
        private readonly IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult> decorated;

        public FinishedFootballStatisticDatabaseErrorHandler(IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<FinishedFootballStatisticDatabaseResult> Handle(FinishedFootballStatisticDatabaseQuery query)
        {
            try
            {
                return await decorated.Handle(query);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to get all Football statistic for finished matches from DB, {ex}");

                return new FinishedFootballStatisticDatabaseResult();
            }
        }
    }
}
