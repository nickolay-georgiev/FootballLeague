using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Team.Validators.Create.Models;

namespace FootballLeague.Services.Implementation.Team.Validators.Create
{
    public sealed class TeamNameIsNotNullOrEmptyValidator : IValidator<CreateTeamValidationModel>
    {
        private const string EMPTY_TEAM_NAME_ERROR_MESSAGE = "Team name can not be empty";

        public ValidationResult Validate(CreateTeamValidationModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Name)) return new ValidationResult(EMPTY_TEAM_NAME_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
