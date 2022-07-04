using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Commands.Update.Match;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Update.Match
{
    public sealed class UpdateSportMatchDatabaseCommandHandler : ICommandHandlerAsync<UpdateSportMatchDatabaseCommand, IResult>
    {
        private readonly IDeletableEntityRepository<SportMatch> repo;

        public UpdateSportMatchDatabaseCommandHandler(IDeletableEntityRepository<SportMatch> repo)
        {
            this.repo = repo;
        }
        public async Task<IResult> Handle(UpdateSportMatchDatabaseCommand command)
        {
            repo.Update(command.SportMatch);
            await repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }
}
