using GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL.Types
{
    public class MapType<TValueGraphType> : ObjectGraphType where TValueGraphType : IGraphType
    {
        public virtual string MapName { get; }
        public MapType()
        {
            Name = $"{MapName}Map";
            Field<NonNullGraphType<StringGraphType>>("key");
            Field<TValueGraphType>("value");
        }
    }

    public class StringMapType : MapType<StringGraphType>
    {
        public override string MapName => "String";
    }

    public class StringListGraphType : MapType<ListGraphType<StringGraphType>>
    {
        public override string MapName => "StringList";
    }

    public class FloatMapType : MapType<FloatGraphType>
    {
        public override string MapName => "Float";
    }
    
    public class CategorisedMetaDataMapType : MapType<ListGraphType<MapType<ListGraphType<StringMapType>>>>
    {
        public override string MapName => "CategorisedMetaData";
    }

    public class SkillInfoMapType : MapType<ListGraphType<SkillInfoType>>
    {
        public override string MapName => "SkillInfoList";
    }
}
