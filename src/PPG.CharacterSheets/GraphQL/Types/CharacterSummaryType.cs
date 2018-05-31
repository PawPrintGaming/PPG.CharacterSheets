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
            Field<NonNullGraphType<IdGraphType>>(nameof(CharacterSummary.Id), resolve: context => context.Source.Id);
            Field(x => x.CharacterName);
            Field(x => x.RuleSet, false, typeof(EnumerationGraphType<RuleSet>));
            Field(x => x.Experience);
            Field<ListGraphType<MapType>>(nameof(CharacterSummary.Stats), resolve: context => context.Source.Stats);
            Field<ListGraphType<MapType>>(nameof(CharacterSummary.MetaData), resolve: context => context.Source.MetaData);
        }

        public override CharacterSummary GetById(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
