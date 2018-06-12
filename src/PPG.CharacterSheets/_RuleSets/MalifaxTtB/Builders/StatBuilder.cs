using PPG.CharacterSheets._RuleSets.MalifaxTtB.Enums;
using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets._RuleSets.MalifaxTtB.Builders
{
    public class StatBuilder : BaseStatBuilderForEnumType<StatNames>
    {
        protected override int defaultValue => 0;
    }
}
