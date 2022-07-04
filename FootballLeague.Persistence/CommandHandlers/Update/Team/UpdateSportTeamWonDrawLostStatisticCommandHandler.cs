using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Enums;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Update;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update.Team
{
    public sealed class UpdateSportTeamWonDrawLostStatisticCommandHandler : ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated;

        public UpdateSportTeamWonDrawLostStatisticCommandHandler(ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(UpdateSportTeamDatabaseCommand command)
        {
            this.UpdateStatistics(command.MatchScore, command.SportTeam);

            var result = await this.decorated.Handle(command);
            if (!result.Succeed) return new FailedResult();

            return new SuccessfulResult();
        }

        private void UpdateStatistics(MatchScore matchScore, SportTeam sportTeam)
        {
            switch (matchScore)
            {
                case MatchScore.Win:
                    sportTeam.TotalWon++;
                    break;
                case MatchScore.Draw:
                    sportTeam.TotalDraw++;
                    break;
                case MatchScore.Loss:
                    sportTeam.TotalLost++;
                    break;
            }
        }
    }
}
