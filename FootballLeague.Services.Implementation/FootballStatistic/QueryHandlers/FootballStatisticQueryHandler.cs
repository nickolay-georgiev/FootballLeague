using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Persistence.Queries.FootballStatistic.Get;
using FootballLeague.Persistence.Result.FootballStatistic.Get;
using FootballLeague.Services.Implementation.FootballStatistic.Queries;
using FootballLeague.Services.Implementation.FootballStatistic.Result;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.FootballStatistic.QueryHandlers
{
    public sealed class FootballStatisticQueryHandler : IAsyncQueryHandler<FootballStatisticQuery, FootballStatisticResult>
    {
        private const string GET_FINISHED_MATCHES_STATISTIC_ERROR_MESSAGE = "Something went wron, please try again or contact the support team.";

        private readonly IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult> handler;

        public FootballStatisticQueryHandler(IAsyncQueryHandler<FinishedFootballStatisticDatabaseQuery, FinishedFootballStatisticDatabaseResult> handler)
        {
            this.handler = handler;
        }

        public async Task<FootballStatisticResult> Handle(FootballStatisticQuery query)
        {
            var result = await this.handler.Handle(new FinishedFootballStatisticDatabaseQuery());
            if (!result.Succeed) return new FootballStatisticResult(GET_FINISHED_MATCHES_STATISTIC_ERROR_MESSAGE);

            return new FootballStatisticResult(result.SportMatches);
        }
    }
}
