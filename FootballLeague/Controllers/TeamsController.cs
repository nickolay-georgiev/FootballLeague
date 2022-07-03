using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Services.Implementation.Team.Commands;
using FootballLeague.Services.Implementation.Team.Models.Result.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class TeamsController : BaseApiController
    {
        private readonly ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler;

        public TeamsController(ICommandHandlerAsync<CreateTeamCommand, CreateTeamResult> createTeamHandler)
        {
            this.createTeamHandler = createTeamHandler;
        }

        /// <summary>
        /// Create and add a NewTeam
        /// </summary>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[SwaggerResponse(StatusCodes.Status201Created, typeof(CreateTeamCommand), "returns a new id of the bla bla")]
        [Produces("application/json")]
        [HttpGet]  //CreateTeamInputModel
        public async Task<ActionResult> Create(Test input)
        {
            var result = await this.createTeamHandler.Handle(new CreateTeamCommand(input.Name));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status201Created);
        }

        public class Test
        {
            [Required]
            public string Name { get; set; }
        }
    }
}
