using GraphQL.Relay.Types;
using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class CharacterSummaryType : NodeGraphType<CharacterSummary>
    {        
        public CharacterSummaryType()
        {
            Name = "CharacterSummary";
            Field(x => x.Id, false, typeof(NonNullGraphType<IdGraphType>));
            Field(x => x.CharacterName, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.Experience, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Stats, false, typeof(NonNullGraphType<ListGraphType<MapType>>));
            Field(x => x.MetaData, false, typeof(NonNullGraphType<ListGraphType<MapType>>));
        }

        public override CharacterSummary GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
