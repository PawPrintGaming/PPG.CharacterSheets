using GraphQL.Relay.Types;
using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class RuleSetInfoType : NodeGraphType<RuleSetInfo>
    {
        public RuleSetInfoType()
        {
            Name = "RuleSetInfo";
            Field(x => x.Id, false, typeof(NonNullGraphType<IdGraphType>));
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.ImageUrl, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.CreateCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.ViewCharacterPath, false, typeof(NonNullGraphType<StringGraphType>));
        }

        public override RuleSetInfo GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
