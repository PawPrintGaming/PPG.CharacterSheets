using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.GraphQL.Helpers;
using System;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public class UpdateCharacterToCharacterSummaryMapper : IMapper<CharacterSummary, UpdateCharacter>
    {
        public Task<UpdateCharacter> MapFrom(CharacterSummary summary)
        {
            throw new NotImplementedException();
        }

        public async Task<CharacterSummary> MapTo(UpdateCharacter update)
        {
            return new CharacterSummary
            {
                Id = update.Id,
                CharacterName = update.CharacterName,
                RuleSet = update.RuleSet,
                Experience = update.Experience,
                Stats = update.Stats.AsDictionary(),
                MetaData = update.MetaData.AsDictionary()
            };
        }
    }
}
