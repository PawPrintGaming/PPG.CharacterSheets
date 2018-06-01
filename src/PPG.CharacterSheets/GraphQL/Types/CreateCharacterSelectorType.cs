using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class CreateCharacterSelectorType : ObjectGraphType<CreateCharacterSelector>
    {
        public CreateCharacterSelectorType()
        {
            Name = "CreateCharacterSelector";

        }
    }
}
