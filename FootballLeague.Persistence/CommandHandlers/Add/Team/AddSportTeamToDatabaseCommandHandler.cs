using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Add.Team;
using FootballLeague.Persistence.Result.Add.Team;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Team
{
    public sealed class AddSportTeamToDatabaseCommandHandler : ICommandHandlerAsync<AddSportTeamToDatabaseCommand, AddSportTeamToDatabaseResult>
    {
        private readonly IRepository<SportTeam> repo;

        public AddSportTeamToDatabaseCommandHandler(IRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public async Task<AddSportTeamToDatabaseResult> Handle(AddSportTeamToDatabaseCommand command)
        {
            await repo.AddAsync(command.Entity);
            await repo.SaveChangesAsync();

            return new AddSportTeamToDatabaseResult();
        }
    }
}
