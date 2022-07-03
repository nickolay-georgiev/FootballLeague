using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Services.Implementation.Team.Commands.Create;
using FootballLeague.Services.Implementation.Team.Commands.Delete;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using FootballLeague.Services.Implementation.Team.Models.Result.Delete;
using FootballLeague.Services.Implementation.Team.Models.Result.GetByUd.Team;
using FootballLeague.Services.Implementation.Team.Queries.GetById.Team;
using FootballLeague.Web.Models.Team.Create;
using FootballLeague.Web.Models.Team.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class TeamsController : BaseApiController
    {
        private readonly IAsyncQueryHandler<TeamByIdQuery, TeamByIdResult> teamByIdHandler;
        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler;
        private readonly ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteTeamByIdResult> deleteTeamHandler;

        public TeamsController(IAsyncQueryHandler<TeamByIdQuery, TeamByIdResult> teamByIdHandler, ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler, ICommandHandlerAsync<DeleteTeamByIdCommand, DeleteTeamByIdResult> deleteTeamHandler)
        {
            this.teamByIdHandler = teamByIdHandler;
            this.createTeamHandler = createTeamHandler;
            this.deleteTeamHandler = deleteTeamHandler;
        }

        /// <summary>
        /// Create and add a NewTeam
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status201Created, typeof(CreateTeamCommand), "returns a new id of the bla bla")]
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
        /// Fetch Team by ID
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
    }
}
