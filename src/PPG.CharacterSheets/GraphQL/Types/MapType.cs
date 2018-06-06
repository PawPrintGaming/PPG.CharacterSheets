using GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class MapType<TValueGraphType> : ObjectGraphType where TValueGraphType : IGraphType
    {
        public MapType()
        {
            Name = "Map";
            Field<NonNullGraphType<StringGraphType>>("key");
            Field<TValueGraphType>("value");
        }
    }

    public class MapType : MapType<StringGraphType> { }
}
