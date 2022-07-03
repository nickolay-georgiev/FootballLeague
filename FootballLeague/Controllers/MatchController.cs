using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Models.Result.Create;
using FootballLeague.Web.Models.Match.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    /// <summary>
    /// Controller for CRUD operations with SportMatch entity
    /// </summary>
    public class MatchController : BaseApiController
    {

        //private readonly IAsyncQueryHandler<TeamByIdQuery, TeamByIdResult> matchByIdHandler;
        private readonly ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler;
        //private readonly ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteTeamByIdResult> deleteMatchHandler;
        //private readonly ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateTeamTotalSeasonScoreResult> updateMatchHandler;

        public MatchController(ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler)
        {
            this.createMatchHandler = createMatchHandler;
        }

        /// <summary>
        /// Create and add a SportMatch
        /// </summary>
        /// <response code="201">Returns status code 201 if creation succeeded</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Create(CreateSportMatchInputModel input)
        {
            var result = await this.createMatchHandler.Handle(new  CreateMatchCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status201Created);
        }
    }
}
