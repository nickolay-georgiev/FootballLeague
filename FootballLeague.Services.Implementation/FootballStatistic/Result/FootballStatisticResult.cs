using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Persistence.Result.FootballStatistic.DTOs;
using System.Collections.Generic;

namespace FootballLeague.Services.Implementation.FootballStatistic.Result
{
    public class FootballStatisticResult : IResult
    {
        public FootballStatisticResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public FootballStatisticResult(ICollection<SportMatchModel> sportMatches)
        {
            Succeed = true;
            SportMatches = sportMatches;
        }

        public bool Succeed { get; }

        public string Message { get; }

        public ICollection<SportMatchModel> SportMatches { get; }
    }
}
