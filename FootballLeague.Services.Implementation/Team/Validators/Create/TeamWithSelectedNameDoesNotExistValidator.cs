using FootballLeague.Abstraction.CQS.Query;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Persistence.Queries.GetByName.Team;
using FootballLeague.Persistence.Result.Team.GetByName;
using FootballLeague.Services.Implementation.Team.Validators.Create.Models;
using System;

namespace FootballLeague.Services.Implementation.Team.Validators.Create
{
    public sealed class TeamWithSelectedNameDoesNotExistValidator : IValidator<CreateTeamValidationModel>
    {
        private const string TEAM_ALREADY_EXIST_ERROR_MESSAGE = "Team with this name already exist.";

        private readonly IQueryHandler<TeamByNameQuery, TeamByNameResult> teamByNameQuery;

        public TeamWithSelectedNameDoesNotExistValidator(IQueryHandler<TeamByNameQuery, TeamByNameResult> teamByNameQuery)
        {
            this.teamByNameQuery = teamByNameQuery;
        }

        public ValidationResult Validate(CreateTeamValidationModel model)
        {
            var result = this.teamByNameQuery.Handle(new TeamByNameQuery(model.Name));

            if (result.SportTeam is not null) return new ValidationResult(TEAM_ALREADY_EXIST_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
