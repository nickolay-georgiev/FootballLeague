using FootballLeague.Abstraction.Validators;
using FootballLeague.IoCContainers.SimpleInjectorBootstraper.Contracts;
using FootballLeague.Services.Implementation.Team.Validators.GetById;
using SimpleInjector;

namespace FootballLeague.IoCContainers.IoCPackages.Common.Validators
{
    internal sealed class SharedValidators : IPackage
    {
        public void RegisterServices(Container container)
        {
            container.Register<IValidator<int>, EntityIdIsBiggerThanZero>(Lifestyle.Singleton);
        }
    }
}
