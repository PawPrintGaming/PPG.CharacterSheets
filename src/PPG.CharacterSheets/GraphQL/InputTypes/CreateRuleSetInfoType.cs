using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class CreateRuleSetInfoType : InputObjectGraphType<RuleSetInfo>
    {
        public CreateRuleSetInfoType()
        {
            Name = "CreateRuleSetInfo";
            Field(x => x.Name);
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.ImageUrl, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Description, true);
            Field(x => x.CreateCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.ViewCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
        }
    }
}
