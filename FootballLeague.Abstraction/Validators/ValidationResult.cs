using System.Collections.Generic;

namespace FootballLeague.Abstraction.Validators
{
    public class ValidationResult
    {
        private readonly Dictionary<string, string> errorMessages;

        public ValidationResult()
        {
            this.errorMessages = new Dictionary<string, string>();
        }

        public ValidationResult(string validationName, string errorMessage)
        {
            this.errorMessages = new Dictionary<string, string>() { { validationName, errorMessage } };
        }

        public ValidationResult(Dictionary<string, string> errorMessages)
        {
            this.errorMessages = errorMessages;
        }

        public bool HasErrors
        {
            get
            {
                return errorMessages.Count > 0;
            }
        }

        public Dictionary<string, string> ErrorMessages
        {
            get
            {
                return this.errorMessages;
            }
        }

        internal void Merge(ValidationResult validationResult)
        {
            foreach (var error in validationResult.ErrorMessages)
            {
                this.ErrorMessages[error.Key] = error.Value;
            }
        }
    }
}
