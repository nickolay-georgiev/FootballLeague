using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Commands.Add.Match;
using FootballLeague.Persistence.Queries.GetById.Team;
using FootballLeague.Persistence.Result.GetById.Team;
using FootballLeague.Services.Implementation.Match.Builders;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Models.Contexts;
using FootballLeague.Services.Implementation.Match.Models.Result.Create;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Create
{
    public sealed class CreateMatchCommandHandler : ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>
    {
        private readonly IValidator<CreateTeamValidationModel> validator;
        private readonly IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler;
        private readonly ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult> addMatchHandler;
        private readonly IDomainEntityBuilder<SportMatch, CreateMatchBuildContext> mathBuilder;

        public CreateMatchCommandHandler(IValidator<CreateTeamValidationModel> validator, IAsyncQueryHandler<TeamByIdDatabaseQuery, TeamByIdDatabaseResult> teamByIdHandler, ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult> addMatchHandler, IDomainEntityBuilder<SportMatch, CreateMatchBuildContext> mathBuilder)
        {
            this.validator = validator;
            this.teamByIdHandler = teamByIdHandler;
            this.addMatchHandler = addMatchHandler;
            this.mathBuilder = mathBuilder;
        }

        public async Task<CreateMatchResult> Handle(CreateMatchCommand command)
        {
            var homeTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.inputModel.HomeTeamId));
            var awayTeamResult = await this.teamByIdHandler.Handle(new TeamByIdDatabaseQuery(command.inputModel.AwayTeamId));

            var validationResult = this.validator.Validate(new CreateTeamValidationModel(homeTeamResult.Entity, awayTeamResult.Entity, command.inputModel.StartDate));
            if (!validationResult.Succeed) return new CreateMatchResult(validationResult.Message);

            var matchBuildResult = this.mathBuilder.Build(new CreateMatchBuildContext(homeTeamResult.Entity, awayTeamResult.Entity, command.inputModel.StartDate));
            if (!matchBuildResult.Succeed) return new CreateMatchResult("Failed to build match model");

            var result = await this.addMatchHandler.Handle(new AddSportMatchToDatabaseCommand(matchBuildResult.Entity));
            if (!result.Succeed) return new CreateMatchResult("Failed to add match in DB");

            return new CreateMatchResult();
        }
    }
}
