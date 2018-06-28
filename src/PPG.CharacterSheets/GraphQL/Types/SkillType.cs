using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class SkillType : ObjectGraphType<Skill>
    {
        public SkillType()
        {
            Name = "Skill";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Rank, false, typeof(NonNullGraphType<IntGraphType>));
            Field(x => x.MetaData, true, typeof(ListGraphType<SkillMetaDataMapType>));
        }
    }
}