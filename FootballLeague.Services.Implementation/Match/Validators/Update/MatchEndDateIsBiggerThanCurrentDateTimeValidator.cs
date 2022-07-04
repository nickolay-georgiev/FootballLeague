using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Update.Models;

namespace FootballLeague.Services.Implementation.Match.Validators.Update
{
    public sealed class MatchEndDateIsBiggerThanCurrentDateTimeValidator : IValidator<UpdateMatchOnGameEndValidationModel>
    {
        private const string END_DATE_BEFORE_START_DATE_ERROR_MESSAGE = "End date can not be equal or before Start date.";

        public ValidationResult Validate(UpdateMatchOnGameEndValidationModel model)
        {
            if (model.StartDate >= model.EndDate ) return new ValidationResult(END_DATE_BEFORE_START_DATE_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
