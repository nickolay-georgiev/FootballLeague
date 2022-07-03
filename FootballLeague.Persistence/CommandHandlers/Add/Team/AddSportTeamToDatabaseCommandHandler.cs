using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Add.Team;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Team
{
    public sealed class AddSportTeamToDatabaseCommandHandler : ICommandHandlerAsync<AddSportTeamToDatabaseCommand, IResult>
    {
        private readonly IDeletableEntityRepository<SportTeam> repo;

        public AddSportTeamToDatabaseCommandHandler(IDeletableEntityRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public async Task<IResult> Handle(AddSportTeamToDatabaseCommand command)
        {
            await repo.AddAsync(command.Entity);
            await repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }
}
