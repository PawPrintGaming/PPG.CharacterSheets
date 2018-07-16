using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class AbilityInputType : InputObjectGraphType<CreateAbility>
    {
        public AbilityInputType()
        {
            Name = "AbilityInput";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.MetaData, false, typeof(NonNullGraphType<ListGraphType<StringInputMapType>>));
        }
    }
}
