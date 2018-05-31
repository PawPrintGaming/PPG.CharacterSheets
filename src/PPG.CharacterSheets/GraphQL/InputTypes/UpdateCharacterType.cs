using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.GraphQL.Helpers;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class UpdateCharacterType : InputObjectGraphType<CharacterSummary>
    {
        public UpdateCharacterType()
        {
            Name = "UpdateCharacter";
            Field(x => x.Id);
            Field(x => x.CharacterName);
            Field(x => x.RuleSet, false, typeof(EnumerationGraphType<RuleSet>));
            Field(x => x.Experience);
            Field<ListGraphType<InputMapType<IntGraphType>>>(nameof(CharacterSummary.Stats), resolve: context => context.Source.Stats.AsMapType());
            Field<ListGraphType<InputMapType<StringGraphType>>>(nameof(CharacterSummary.MetaData), resolve: context => context.Source.MetaData.AsMapType());

        }
    }
}
