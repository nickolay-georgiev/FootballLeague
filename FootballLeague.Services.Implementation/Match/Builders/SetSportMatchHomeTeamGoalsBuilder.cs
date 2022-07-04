using FootballLeague.Abstraction.Builders;
using FootballLeague.Abstraction.CQS.Result;
using FootballLeague.Data.Models.Match;
using FootballLeague.Services.Implementation.Match.Models.Contexts;

namespace FootballLeague.Services.Implementation.Match.Builders
{
    public sealed class SetSportMatchHomeTeamGoalsBuilder : IBuilder<SportMatch, UpdateMatchContext>
    {
        public IResult Build(SportMatch entity, UpdateMatchContext context)
        {
            entity.HomeTeamGoals = context.HomeTeamGoals;

            return new SuccessfulResult();
        }
    }
}
