using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Abstraction.Validators
{
    public class ValidationResult : IResult
    {
        public ValidationResult()
        {
            Succeed = true;
        }

        public ValidationResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
