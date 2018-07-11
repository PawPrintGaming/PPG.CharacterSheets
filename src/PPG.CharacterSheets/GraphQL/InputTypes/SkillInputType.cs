using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class SkillInputType : InputObjectGraphType<CreateSkill>
    {
        public SkillInputType()
        {
            Name = "SkillInput";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Rank, false, typeof(IntGraphType));
            Field(x => x.MetaData, true, typeof(ListGraphType<SkillMetaDataInputMapType>));
        }
    }
}
