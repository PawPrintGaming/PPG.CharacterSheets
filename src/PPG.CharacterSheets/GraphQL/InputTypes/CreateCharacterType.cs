using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class CreateCharacterType : InputObjectGraphType<CreateCharacter>
    {
        public CreateCharacterType()
        {
            Name = "CreateCharacter";
            Field(x => x.CharacterName);
            Field(x => x.Ruleset, type: typeof(EnumerationGraphType<RuleSet>));
            Field<ListGraphType<InputMapType<IntGraphType>>>(nameof(CreateCharacter.Stats));
            Field<ListGraphType<InputMapType<StringGraphType>>>(nameof(CreateCharacter.MetaData));
        }
    }
}
