using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class CreateCharacterType : InputObjectGraphType<CreateCharacter>
    {
        public CreateCharacterType()
        {
            Name = "CreateCharacter";
            Field(x => x.CharacterName, false);
            Field(x => x.RuleSet, false,  typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.Stats, true, typeof(ListGraphType<IntInputMapType>));
            Field(x => x.MetaData, true, typeof(ListGraphType<StringInputMapType>));
            Field(x => x.Skills, true, typeof(ListGraphType<SkillInputType>));
            Field(x => x.Wallets, true, typeof(ListGraphType<FloatInputMapType>));
        }
    }
}