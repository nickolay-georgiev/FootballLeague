using FootballLeague.Abstraction.CQS.Command;

namespace FootballLeague.Services.Implementation.Team.Commands
{
    public class CreateTeamCommand : ICommand
    {
        public CreateTeamCommand(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
