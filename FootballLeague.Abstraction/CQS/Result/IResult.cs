namespace FootballLeague.Abstraction.CQS.Result
{
    public interface IResult
    {
        bool Succeed { get; }
    }
    public class FailedResult : IResult
    {
        public bool Succeed => false;
    }

    public class SuccessfulResult : IResult
    {
        public bool Succeed => true;
    }
}
