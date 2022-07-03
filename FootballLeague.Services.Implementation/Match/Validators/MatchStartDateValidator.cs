using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;
using System;

namespace FootballLeague.Services.Implementation.Match.Validators
{
    public class MatchStartDateValidator : IValidator<CreateTeamValidationModel>
    {
        private const string INVALID_START_DATE_ERROR_MESSAGE = "Invalid match start date";

        public ValidationResult Validate(CreateTeamValidationModel model)
        {
            if (model.StartDate <= DateTime.UtcNow) return new ValidationResult(INVALID_START_DATE_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
