using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Team;

namespace FootballLeague.Services.Implementation.Team.Models.Result.GetById.Team
{
    public class TeamByIdResult : IResult
    {
        public TeamByIdResult(SportTeam entity)
        {
            Succeed = true;
            Entity = entity;
        }

        public TeamByIdResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }

        public SportTeam Entity { get; }
    }


}
