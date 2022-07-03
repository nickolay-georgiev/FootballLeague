using FootballLeague.Abstraction.CQS.Command;
using FootballLeague.Abstraction.Validators;
using FootballLeague.Services.Implementation.Match.Commands.Create;
using FootballLeague.Services.Implementation.Match.Models.Result.Create;
using FootballLeague.Services.Implementation.Match.Validators.Create.Models;
using System.Threading.Tasks;

namespace FootballLeague.Services.Implementation.Match.CommandHandlers.Create
{
    public sealed class CreateMatchCommandHandler : ICommandHandlerAsync<CreateMatchCommand, CreateMatchResult>
    {
        private readonly IValidator<CreateTeamValidationModel> validator;

        public async Task<CreateMatchResult> Handle(CreateMatchCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
