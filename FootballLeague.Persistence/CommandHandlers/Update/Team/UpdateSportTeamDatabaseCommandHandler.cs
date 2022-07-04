using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Update;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update
{
    public sealed class UpdateSportTeamDatabaseCommandHandler : ICommandHandlerAsync<UpdateSportTeamDatabaseCommand, IResult>
    {
        private readonly IDeletableEntityRepository<SportTeam> repo;

        public UpdateSportTeamDatabaseCommandHandler(IDeletableEntityRepository<SportTeam> repo)
        {
            this.repo = repo;
        }
        public async Task<IResult> Handle(UpdateSportTeamDatabaseCommand command)
        {
            this.repo.Update(command.SportTeam);
            await this.repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }
}
