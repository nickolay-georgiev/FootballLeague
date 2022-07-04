using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Common.Logging;
using FootballLeague.Persistence.Commands.Add.Match;
using System;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Match
{
    public sealed class AddSportMatchToDatabaseErrorHandler : ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>
    {
        private readonly ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult> decorated;

        public AddSportMatchToDatabaseErrorHandler(ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult> decorated)
        {
            this.decorated = decorated;
        }

        public async Task<IResult> Handle(AddSportMatchToDatabaseCommand command)
        {
            try
            {
                return await decorated.Handle(command);
            }
            catch (Exception ex)
            {
                Logger.WriteLog($"Failed to add match with startDate {command.Entity.StartDate} and teamIds: {command.Entity.HomeTeamId} & {command.Entity.AwayTeam} to DB, {ex}");

                return new FailedResult();
            }
        }
    }
}
