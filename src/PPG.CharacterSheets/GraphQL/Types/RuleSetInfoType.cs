using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class RuleSetInfoType : ObjectGraphType<RuleSetInfo>
    {
        public RuleSetInfoType()
        {
            Name = "RuleSetInfo";
            Field<IdGraphType>(nameof(RuleSetInfo.Id), resolve: context => context.Source.Id);
            Field(x => x.Name);
            Field(x => x.RuleSet, false, typeof(EnumerationGraphType<RuleSet>));
            Field(x => x.CoverImageUrl);
        }
    }
}
