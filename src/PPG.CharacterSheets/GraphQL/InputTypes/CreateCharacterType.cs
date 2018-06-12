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
            Field(x => x.CharacterName, false);
            Field(x => x.RuleSet, false,  typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.Stats, true, typeof(ListGraphType<InputMapType<IntGraphType>>));
            Field(x => x.MetaData, true, typeof(ListGraphType<InputMapType<StringGraphType>>));
        }
    }
}
