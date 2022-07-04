using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Persistence.Result.FootballStatistic.DTOs;
using System;
using System.Collections.Generic;

namespace FootballLeague.Persistence.Result.FootballStatistic.Get
{
    public class FinishedFootballStatisticDatabaseResult : IResult
    {
        public FinishedFootballStatisticDatabaseResult()
        {
            Succeed = false;
        }

        public FinishedFootballStatisticDatabaseResult(ICollection<SportMatchModel> sportMatches)
        {
            Succeed = true;
            SportMatches = sportMatches;
        }

        public bool Succeed { get; }

        public ICollection<SportMatchModel> SportMatches { get; }
    }
}
