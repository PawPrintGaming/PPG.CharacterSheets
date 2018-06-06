using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets.Characters.Factories
{
    public interface ICreateCharacterInfoBuilderFactory
    {
        ICreateCharacterInfoBuilder Resolve(RuleSet ruleSet);
    }
}
