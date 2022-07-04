using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Update.Models;

namespace FootballLeague.Services.Implementation.Match.Validators.Update
{
    public sealed class HomeTeamGoalsCountIsEqualOrBiggerThanZeroValidator : IValidator<UpdateMatchOnGameEndValidationModel>
    {
        private const string INVALID_GOALS_COUNT_ERROR_MESSAGE = "Home Team goals count can not be less than zero.";

        public ValidationResult Validate(UpdateMatchOnGameEndValidationModel model)
        {
            if (0 > model.HomeTeamGoals) return new ValidationResult(INVALID_GOALS_COUNT_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
