using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Validators.Delete.Models;

namespace FootballLeague.Services.Implementation.Match.Validators.Delete
{
    public sealed class SportMatchIsFinishedOnDeleteCommandValidator : IValidator<DeleteSportMachValidationModel>
    {
        private const string DELETE_NOT_FINISHED_MATCH_ERROR_MESSAGE = "You can not delete match which is not finished yet!";

        public ValidationResult Validate(DeleteSportMachValidationModel model)
        {
            if (model.EndDate is null) return new ValidationResult(DELETE_NOT_FINISHED_MATCH_ERROR_MESSAGE);

            return new ValidationResult();
        }
    }
}
