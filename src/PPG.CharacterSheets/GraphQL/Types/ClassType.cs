using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class ClassType : ObjectGraphType<Class>
    {
        public ClassType()
        {
            Name = "Class";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Rank, true, typeof(IntGraphType));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.MetaData, true, typeof(ListGraphType<StringMapType>));
        }
    }
}