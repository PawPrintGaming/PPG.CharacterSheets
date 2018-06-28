using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class SkillInfoType : ObjectGraphType<SkillInfo>
    {
        public SkillInfoType()
        {
            Name = "SkillInfo";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.StatKeys, true, typeof(ListGraphType<StringGraphType>));

        }
    }
}
