﻿using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Common.GetById;
using FootballLeague.Services.Implementation.Common.Results.Delete;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Commands.Delete;
using FootballLeague.Services.Implementation.Match.Models.Result.Create;
using FootballLeague.Services.Implementation.Match.Queries.GetById;
using FootballLeague.Web.Models.Match.Create;
using FootballLeague.Web.Models.Match.GetById;
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

        private readonly IAsyncQueryHandler<MatchByIdQuery, EntityByIdResult<SportMatch>> matchByIdHandler;
        private readonly ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler;
        private readonly ICommandHandlerAsync<DeleteMatchByIdCommand, DeleteEntityByIdResult<SportMatch>> deleteMatchHandler;
        //private readonly ICommandHandlerAsync<UpdateTeamTotalSeasonScoreCommand, UpdateTeamTotalSeasonScoreResult> updateMatchHandler;

        public MatchController(IAsyncQueryHandler<MatchByIdQuery, EntityByIdResult<SportMatch>> matchByIdHandler, ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult> createMatchHandler, ICommandHandlerAsync<DeleteMatchByIdCommand, DeleteEntityByIdResult<SportMatch>> deleteMatchHandler)
        {
            this.matchByIdHandler = matchByIdHandler;
            this.createMatchHandler = createMatchHandler;
            this.deleteMatchHandler = deleteMatchHandler;
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
            var result = await this.createMatchHandler.Handle(new CreateMatchCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Fetch Match by ID
        /// </summary>
        /// <response code="200">Returns the desired match by ID</response>
        /// <response code="400">If any validation or DB error occurs</response>
        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] MatchByIdInputModel input)
        {
            var result = await this.matchByIdHandler.Handle(new MatchByIdQuery(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.Ok(result.Entity);
        }

        /// <summary>
        /// Delete Match by ID and 
        /// </summary>
        /// <response code="204">On successful deletion</response>
        /// <response code="400">If any validation or DB error occurs</response>
        [HttpDelete]
        public async Task<ActionResult> DeleteById([FromQuery] MatchByIdInputModel input)
        {
            var result = await this.deleteMatchHandler.Handle(new DeleteMatchByIdCommand(input));

            if (!result.Succeed) return BadRequest(result.Message);

            return this.StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
