using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Team;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Team.Commands.Create;
using FootballLeague.Services.Implementation.Team.Commands.Delete;
using FootballLeague.Services.Implementation.Team.Commands.Update;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using FootballLeague.Services.Implementation.Team.Models.Result.Update;
using FootballLeague.Services.Implementation.Team.Queries.GetById.Team;
using FootballLeague.Web.Models.Team.Create;
using FootballLeague.Web.Models.Team.GetById;
using FootballLeague.Web.Models.Team.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    /// <summary>
    /// Controller for CRUD operations with SportTeam entity
    /// </summary>
    public class TeamsController : BaseApiController
    {
        private readonly IAsyncQueryHandler<TeamByIdQuery, EntityByIdResult<SportTeam>> teamByIdHandler;
        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler;
        private readonly ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteEntityByIdResult<SportTeam>> deleteTeamHandler;
        private readonly ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateTeamTotalSeasonScoreResult> updateTeamHandler;

        /// <summary>
        /// TeamsController constructor
        /// </summary>
        public TeamsController(IAsyncQueryHandler<TeamByIdQuery, EntityByIdResult<SportTeam>> teamByIdHandler, ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler, ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteEntityByIdResult<SportTeam>> deleteTeamHandler, ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateTeamTotalSeasonScoreResult> updateTeamHandler)
        {
            this.teamByIdHandler = teamByIdHandler;
            this.createTeamHandler = createTeamHandler;
            this.deleteTeamHandler = deleteTeamHandler;
            this.updateTeamHandler = updateTeamHandler;
        }

        /// <summary>
        /// Create and add a NewTeam
        /// </summary>
        /// <response code="201">Returns status code 201 if creation succeeded</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult> Create(CreateTeamInputModel input)
        {
            var result = await this.createTeamHandler.Handle(new CreateTeamCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Fetch Team by ID
        /// </summary>
        /// <response code="200">Returns the desired team by ID</response>
        /// <response code="400">If any validation or DB error occurs</response>
        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] TeamByIdInputModel input)
        {
            var result = await this.teamByIdHandler.Handle(new TeamByIdQuery(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.Ok(result.Entity);
        }

        /// <summary>
        /// Delete Team by ID and 
        /// </summary>
        /// <response code="204">On successful deletion</response>
        /// <response code="400">If any validation or DB error occurs</response>
        [HttpDelete]
        public async Task<ActionResult> DeleteById([FromQuery] TeamByIdInputModel input)
        {
            var result = await this.deleteTeamHandler.Handle(new DeleteTeamByIdCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status204NoContent);
        }

        /// <summary>
        /// Update Team by ID, perform the MatchScore logic
        /// </summary>
        /// <response code="200">On successful update</response>
        /// <response code="400">If any validation or DB error occurs</response>
        [HttpPatch]
        public async Task<ActionResult> Update([FromQuery] UpdateTeamTotalSeasonScoreInputModel input)
        {
            var result = await this.updateTeamHandler.Handle(new UpdateTeamTotalSeasonScoreCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.Ok();
        }
    }
}
