using FootballLeague.Abstraction.Validators;

namespace FootballLeague.Services.Implementation.Team.Validators.GetById
{
    public sealed class EntityIdIsBiggerThanZero : IValidator<int>
    {
        private const string ENTITY_ID_CAN_NOT_BE_LESS_THAN_ONE_ERROR_MESSAGE = "Team ID must be bigger or equal ONE.";

        public ValidationResult Validate(int id)
        {
            if (0 >= id)
            {
                return new ValidationResult(ENTITY_ID_CAN_NOT_BE_LESS_THAN_ONE_ERROR_MESSAGE);
            }

            return new ValidationResult();
        }
    }
}
