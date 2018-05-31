using GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class MapType : ObjectGraphType
    {
        public MapType()
        {
            Name = "Map";
            Field<StringGraphType>("key");
            Field<StringGraphType>("value");
        }
    }
}
