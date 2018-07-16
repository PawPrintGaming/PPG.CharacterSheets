using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Mappers;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class ClassMapperFactory : IClassMapperFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public ClassMapperFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IClassMapper Resolve(RuleSet ruleSet)
        {
            return _serviceProvider.Resolve<IClassMapper>();
        }
    }
}
