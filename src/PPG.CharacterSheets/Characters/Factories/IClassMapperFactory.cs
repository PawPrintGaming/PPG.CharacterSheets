using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Mappers;

namespace PPG.CharacterSheets.Characters.Factories
{
    public interface IClassMapperFactory
    {
        IClassMapper Resolve(RuleSet ruleSet);
    }
}
