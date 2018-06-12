using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class UpdateRuleSetInfoType : InputObjectGraphType<RuleSetInfo>
    {
        public UpdateRuleSetInfoType()
        {
            Name = "UpdateRuleSetInfo";
            Field(x => x.Id, false, typeof(NonNullGraphType<IdGraphType>));
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.RuleSet, false, typeof(EnumerationGraphType<RuleSet>));
            Field(x => x.ImageUrl, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.CreateCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.ViewCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
        }
    }
}
