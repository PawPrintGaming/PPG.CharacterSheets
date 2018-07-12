using GraphQL.Types;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class InputMapType<TValueGraphType> : InputObjectGraphType where TValueGraphType : GraphType
    {
        public virtual string MapName => "";
        public InputMapType()
        {
            Name = $"{MapName}InputMap";
            Field<StringGraphType>("key");
            Field<TValueGraphType>("value");
        }
    }

    public class StringInputMapType : InputMapType<StringGraphType>
    {
        public override string MapName => "String";
    }

    public class IntInputMapType : InputMapType<IntGraphType>
    {
        public override string MapName => "Int";
    }

    public class FloatInputMapType : InputMapType<FloatGraphType>
    {
        public override string MapName => "Float";
    }

    public class DictionaryStringMapType : InputMapType<ListGraphType<StringInputMapType>>
    {
        public override string MapName => "StringDictionary";
    }

    public class SkillMetaDataInputMapType : InputMapType<ListGraphType<InputMapType<ListGraphType<StringInputMapType>>>>
    {
        public override string MapName => "SkillMetaData";
    }
}
