using PPG.CharacterSheets._RuleSets;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Factories;
using PPG.CharacterSheets.Core.Services;
using PPG.CharacterSheets.ErrorHandling;
using System;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services
{
    public class CreateCharacterMapper : IMapper<CharacterSummary, CreateCharacter>
    {
        private readonly IMetaDataBuilderFactory _metaDataBuilderFactory;
        private readonly IStatBuilderFactory _statBuilderFactory;

        public CreateCharacterMapper(IMetaDataBuilderFactory metaDataBuilderFactory, IStatBuilderFactory statBuilderFactory)
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
            var defaultedStats = await statBuilder.Build(createCharacter.Stats).ConfigureAwait(false);

            var metaDataBuilder = _metaDataBuilderFactory.Resolve(ruleSet);
            var defaultedMetaData = await metaDataBuilder.Build(createCharacter.MetaData).ConfigureAwait(false);

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
