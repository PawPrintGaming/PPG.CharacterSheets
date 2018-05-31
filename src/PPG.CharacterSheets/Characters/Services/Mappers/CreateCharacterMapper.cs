using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.ErrorHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public class CreateCharacterToCharacterSummaryMapper : IMapper<CharacterSummary, CreateCharacter>
    {
        private readonly IMetaDataBuilderFactory _metaDataBuilderFactory;
        private readonly IStatBuilderFactory _statBuilderFactory;

        public CreateCharacterToCharacterSummaryMapper(IMetaDataBuilderFactory metaDataBuilderFactory, IStatBuilderFactory statBuilderFactory)
        {
            _metaDataBuilderFactory = metaDataBuilderFactory;
            _statBuilderFactory = statBuilderFactory;
        }

        public async Task<CharacterSummary> MapTo(CreateCharacter createCharacter)
        {
            RuleSet ruleSet;
            if (!Enum.TryParse(createCharacter.Ruleset, out ruleSet))
            {
                throw new PPGException($"Could not parse Rule Set {createCharacter.Ruleset}");
            }

            var statBuilder = _statBuilderFactory.Resolve(ruleSet);
            var dictionaryStats = new Dictionary<string, int>();
            createCharacter.Stats?.ToList().ForEach(stat =>
                dictionaryStats.Add(stat.Key, stat.Value)
            );
            var defaultedStats = await statBuilder.Build(dictionaryStats).ConfigureAwait(false);

            var metaDataBuilder = _metaDataBuilderFactory.Resolve(ruleSet);
            var dictionaryMetaData = new Dictionary<string, string>();
            createCharacter.MetaData?.ToList().ForEach(data =>
            {
                dictionaryMetaData.Add(data.Key, data.Value);
            });
            var defaultedMetaData = await metaDataBuilder.Build(dictionaryMetaData).ConfigureAwait(false);

            return new CharacterSummary
            {
                CharacterName = createCharacter.CharacterName,
                RuleSet = ruleSet,
                Experience = 0,
                Stats = defaultedStats,
                MetaData = defaultedMetaData
            };
        }

        public Task<CreateCharacter> MapFrom(CharacterSummary characterSummary)
        {
            throw new NotImplementedException();
        }

    }
}
