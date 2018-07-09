using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class CharacterRuleSetInfoType : ObjectGraphType<CharacterRuleSetInfo>
    {
        public CharacterRuleSetInfoType()
        {
            Name = "CharacterRuleSetInfo";
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.StatSets, false, typeof(NonNullGraphType<ListGraphType<StringListGraphType>>));
            Field(x => x.SkillInfoSets, false, typeof(NonNullGraphType<ListGraphType<SkillInfoMapType>>));
            Field(x => x.DataLists, false, typeof(NonNullGraphType<ListGraphType<StringListGraphType>>));
        }
    }
}