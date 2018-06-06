using GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class InputMapType<TValueGraphType> : InputObjectGraphType where TValueGraphType : GraphType
    {
        public InputMapType()
        {
            Name = "InputMap";
            Field<NonNullGraphType<StringGraphType>>("key");
            Field<TValueGraphType>("value");
        }
    }
}
