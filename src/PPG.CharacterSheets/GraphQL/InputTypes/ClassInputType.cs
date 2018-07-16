using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class ClassInputType : InputObjectGraphType<CreateClass>
    {
        public ClassInputType()
        {
            Name = "ClassInput";
            Field(x => x.Name, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.Rank, true, typeof(IntGraphType));
            Field(x => x.Description, true, typeof(StringGraphType));
            Field(x => x.MetaData, true, typeof(ListGraphType<StringInputMapType>));
        }
    }
}