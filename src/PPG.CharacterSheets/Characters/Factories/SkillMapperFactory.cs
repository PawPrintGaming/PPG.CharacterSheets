using System;
using Autofac;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets.Characters.Factories
{
    public class SkillMapperFactory : ISkillMapperFactory
    {
        private readonly ILifetimeScope _serviceProvider;

        public SkillMapperFactory(ILifetimeScope serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ISkillMapper Resolve(RuleSet ruleSet)
        {
            return _serviceProvider.Resolve<ISkillMapper>();
        }
    }
}
