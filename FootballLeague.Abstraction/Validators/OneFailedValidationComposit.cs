using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague.Abstraction.Validators
{
    public interface IValidator<in T>
    {
        ValidationResult Validate(T model);
    }

    public sealed class OneFailedValidationComposit<T> : IValidator<T>
    {
        private readonly IEnumerable<IValidator<T>> validators;

        public OneFailedValidationComposit(IEnumerable<IValidator<T>> validators)
        {
            this.validators = validators;
        }

        public ValidationResult Validate(T model)
        {
            ValidationResult validationResult = new ValidationResult();
            foreach (var validator in validators)
            {
                validationResult = validator.Validate(model);

                if (!validationResult.Succeed)
                {
                    break;
                }
            }

            return validationResult;
        }
    }
}
