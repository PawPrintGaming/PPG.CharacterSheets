using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Mappers;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class AbilityMapperFactory : IAbilityMapperFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public AbilityMapperFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IAbilityMapper Resolve(RuleSet ruleSet)
        {
            return _serviceProvider.Resolve<IAbilityMapper>();
        }
    }
}
