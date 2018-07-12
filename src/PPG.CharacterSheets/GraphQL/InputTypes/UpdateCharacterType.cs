using GraphQL.Types;
using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.GraphQL.InputTypes
{
    public class UpdateCharacterType : InputObjectGraphType<CharacterSummary>
    {
        public UpdateCharacterType()
        {
            Name = "UpdateCharacter";
            Field(x => x.Id, false, typeof(NonNullGraphType<IdGraphType>));
            Field(x => x.CharacterName, false, typeof(NonNullGraphType<StringGraphType>));
            Field(x => x.RuleSet, false, typeof(NonNullGraphType<EnumerationGraphType<RuleSet>>));
            Field(x => x.Stats, false, typeof(NonNullGraphType<ListGraphType<IntInputMapType>>));
            Field(x => x.MetaData, false, typeof(NonNullGraphType<ListGraphType<StringInputMapType>>));
            Field(x => x.Skills, true, typeof(ListGraphType<SkillInputType>));
            Field(x => x.Wallets, true, typeof(ListGraphType<FloatInputMapType>));

        }
    }
}
