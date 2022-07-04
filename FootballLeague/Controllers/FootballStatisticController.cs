using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Services.Implementation.FootballStatistic.Queries;
using FootballLeague.Services.Implementation.FootballStatistic.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class FootballStatisticController : BaseApiController
    {
        private readonly IAsyncQueryHandler<FootballStatisticQuery, FootballStatisticResult> handler;

        public FootballStatisticController(IAsyncQueryHandler<FootballStatisticQuery, FootballStatisticResult> handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Currently get all finished matches with teams without any filter parameters!
        /// </summary>
        /// <response code="200">Returns status code 200 on succeeded request</response>
        /// <response code="400">If any error occurs with appropriate message</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Get()
        {
            var result = await this.handler.Handle(new FootballStatisticQuery());

            if (!result.Succeed) return BadRequest(result.Message);

            return this.Ok(result.SportMatches);
        }
    }
}
