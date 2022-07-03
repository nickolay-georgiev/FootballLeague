using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;

namespace FootballLeague.Services.Implementation.Match.Validators
{
    public sealed class AwayTeamIsNotNullValidator : IValidator<CreateTeamValidationModel>
    {
        public ValidationResult Validate(CreateTeamValidationModel model)
        {
            if (model.AwayTeam is null) return new ValidationResult("Away team was not found.");

            return new ValidationResult();
        }
    }
}
