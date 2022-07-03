using FootballLeague.Abstraction.CQS.Result;

namespace FootballLeague.Persistence.Result.Add.Team
{
    public class AddSportTeamToDatabaseResult : IResult
    {
        public AddSportTeamToDatabaseResult()
        {
            Succeed = true;
        }

        public AddSportTeamToDatabaseResult(string message)
        {
            Succeed = false;
            Message = message;
        }

        public bool Succeed { get; }

        public string Message { get; }
    }
}
