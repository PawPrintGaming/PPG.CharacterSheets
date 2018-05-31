using GraphQL.Types;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Services;

namespace PPG.CharacterSheets.GraphQL
{
    public class CharactersSchema : Schema
    {
        public CharactersSchema(
            ICRUDService<Character, CharacterSummary> crudService,
            IMapper<CharacterSummary, CreateCharacter> createMapper,
            IMapper<CharacterSummary, UpdateCharacter> updateMapper
        )
        {
            Query = new CharactersQuery(crudService);
            Mutation = new CharactersMutation(crudService, createMapper, updateMapper);
        }
    }
}
