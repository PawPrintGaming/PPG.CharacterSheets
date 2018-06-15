using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Characters.Services;
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
            IMapper<CharacterSummary, UpdateCharacter> updateMapper,
            ICreateCharacterInfoBuilderFactory createCharacterInfoBuilderFactory,
            ICharacterPolymorphService characterPolymorphService
        )
        {
            Query = new Queries(characterCRUDService, ruleSetInfoCRUDService, createCharacterInfoBuilderFactory);
            Mutation = new Mutations(characterCRUDService, ruleSetInfoCRUDService, createMapper, updateMapper, characterPolymorphService);
        }
    }
}
