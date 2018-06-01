using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.RuleSets.Entities;

namespace PPG.CharacterSheets.GraphQL
{
    public class CharactersSchema : Schema
    {
        public CharactersSchema(
            ICRUDService<Character, CharacterSummary> characterCRUDService,
            ICRUDService<RuleSetInfo> ruleSetInfoCRUDService,
            IMapper<CharacterSummary, CreateCharacter> createMapper,
            IMapper<CharacterSummary, UpdateCharacter> updateMapper
        )
        {
            Query = new CharactersQuery(characterCRUDService, ruleSetInfoCRUDService);
            Mutation = new CharactersMutation(characterCRUDService, ruleSetInfoCRUDService, createMapper, updateMapper);
        }
    }
}
