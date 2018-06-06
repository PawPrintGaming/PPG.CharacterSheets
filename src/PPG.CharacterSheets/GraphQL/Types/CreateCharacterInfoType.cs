using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class CreateCharacterInfoType : ObjectGraphType<CreateCharacterInfo>
    {
        public CreateCharacterInfoType()
        {
            Name = "CreateCharacterInfo";
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.StatSets, false, typeof(NonNullGraphType<ListGraphType<MapType>>));
            Field(x => x.DataLists, false, typeof(NonNullGraphType<ListGraphType<MapType>>));
        }
    }
}