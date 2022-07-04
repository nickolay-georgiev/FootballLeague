using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Match.Models.Contexts;

namespace FootballLeague.Services.Implementation.Match.Builders
{
    public sealed class SetSportMatchAwayTeamGoalsBuilder : IBuilder<SportMatch, UpdateMatchContext>
    {
        public IResult Build(SportMatch entity, UpdateMatchContext context)
        {
            entity.AwayTeamGoals = context.AwayTeamGoals;

            return new SuccessfulResult();
        }
    }
}
