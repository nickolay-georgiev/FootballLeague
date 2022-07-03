using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Common.Repositories;
using FootballLeague.Data.Models.Match;
using FootballLeague.Persistence.Commands.Add.Match;
using System.Threading.Tasks;

namespace FootballLeague.Persistence.CommandHandlers.Add.Match
{
    public sealed class AddSportMatchToDatabaseCommandHandler : ICommandHandlerAsync<AddSportMatchToDatabaseCommand, IResult>
    {
        private readonly IDeletableEntityRepository<SportMatch> repo;

        public AddSportMatchToDatabaseCommandHandler(IDeletableEntityRepository<SportMatch> repo)
        {
            this.repo = repo;
        }

        public async Task<IResult> Handle(AddSportMatchToDatabaseCommand command)
        {
            await repo.AddAsync(command.Entity);
            await repo.SaveChangesAsync();

            return new SuccessfulResult();
        }
    }
}
