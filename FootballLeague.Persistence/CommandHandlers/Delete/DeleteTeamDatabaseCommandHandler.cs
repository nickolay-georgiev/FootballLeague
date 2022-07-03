using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Team;
using FootballLeague.Persistence.Commands.Delete.Team;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Delete
{
    public sealed class DeleteTeamDatabaseCommandHandler : ICommandHandlerAsync<DeleteTeamDatabaseCommand, IResult>
    {
        private readonly IDeletableEntityRepository<SportTeam> repo;

        public DeleteTeamDatabaseCommandHandler(IDeletableEntityRepository<SportTeam> repo)
        {
            this.repo = repo;
        }

        public async Task<IResult> Handle(DeleteTeamDatabaseCommand command)
        {
            this.repo.Delete(command.SportTeam);
            await this.repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }
}
