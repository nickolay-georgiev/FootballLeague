using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Commands.Update.Match;
using FootballLeague.Persistence.Queries.GetById;
using FootballLeague.Persistence.Queries.GetById.Match;
using FootballLeague.Services.Implementation.Common.Results.Update;
using FootballLeague.Services.Implementation.Match.Commands;
using FootballLeague.Services.Implementation.Match.Models.Contexts;
using FootballLeague.Services.Implementation.Match.Validators.Update.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Update
{
    public sealed class UpdateMatchOnGameEndCommandHandler : ICommandHandlerAsync<UpdateMatchOnGameEndCommand, UpdateEntityResult>
    {
        private readonly IValidator<UpdateMatchOnGameEndValidationModel> validator;
        private readonly List<IBuilder<SportMatch, UpdateMatchContext>> builder;
        private readonly ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> updateMatchHandler;
        private readonly IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> teamByIdHandler;

        public UpdateMatchOnGameEndCommandHandler(IValidator<UpdateMatchOnGameEndValidationModel> validator, List<IBuilder<SportMatch, UpdateMatchContext>> builder, ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult> updateMatchHandler, IAsyncQueryHandler<EntityByIdDatabaseQuery<EntityByIdDatabaseResult<SportMatch>>, EntityByIdDatabaseResult<SportMatch>> teamByIdHandler)
        {
            this.validator = validator;
            this.builder = builder;
            this.updateMatchHandler = updateMatchHandler;
            this.teamByIdHandler = teamByIdHandler;
        }

        public async Task<UpdateEntityResult> Handle(UpdateMatchOnGameEndCommand command)
        {
            var getMatchResult = await this.teamByIdHandler.Handle(new MatchByIdDatabaseQuery(command.InputModel.Id));
            if (!getMatchResult.Succeed) return new UpdateEntityResult(getMatchResult.Message);

            var validationResult = this.validator.Validate(new UpdateMatchOnGameEndValidationModel(command.InputModel.HomeTeamGoals, command.InputModel.AwayTeamGoals, getMatchResult.Entity.StartDate, command.InputModel.EndDate));
            if (!validationResult.Succeed) return new UpdateEntityResult(validationResult.Message);

             this.builder.ForEach(x =>x.Build(getMatchResult.Entity, new UpdateMatchContext(command.InputModel.HomeTeamGoals, command.InputModel.AwayTeamGoals, command.InputModel.EndDate)));

            var updateResult = await this.updateMatchHandler.Handle(new UpdateSportMatchDatabaseCommand(getMatchResult.Entity));
            if (!updateResult.Succeed) return new UpdateEntityResult("Failed to update SportMatch");

            return new UpdateEntityResult();
        }
    }
}
