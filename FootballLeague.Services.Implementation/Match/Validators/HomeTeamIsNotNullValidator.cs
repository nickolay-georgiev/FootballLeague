using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;

namespace FootballLeague.Services.Implementation.Match.Validators
{
    public sealed class HomeTeamIsNotNullValidator : IValidator<CreateTeamValidationModel>
    {
        public ValidationResult Validate(CreateTeamValidationModel model)
        {
            if (model.HomeTeam is null) return new ValidationResult("Home team was not found.");

            return new ValidationResult();
        }
    }
}
