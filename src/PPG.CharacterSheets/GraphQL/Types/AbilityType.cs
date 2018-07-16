using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class AbilityType : ObjectGraphType<Ability>
    {
        public AbilityType()
        {
            Name = "Ability";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.MetaData, false, typeof(NonNullGraphType<ListGraphType<StringMapType>>));
        }
    }
}
