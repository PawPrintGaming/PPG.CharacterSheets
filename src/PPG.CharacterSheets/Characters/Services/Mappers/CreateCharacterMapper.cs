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
        private readonly ISkillMapperFactory _skillMapperFactory;
        private readonly IStatBuilderFactory _statBuilderFactory;

        public CreateCharacterToCharacterSummaryMapper(IMetaDataBuilderFactory metaDataBuilderFactory, ISkillMapperFactory skillMapperFactory,IStatBuilderFactory statBuilderFactory)
        {
            _metaDataBuilderFactory = metaDataBuilderFactory;
            _skillMapperFactory = skillMapperFactory;
            _statBuilderFactory = statBuilderFactory;
        }

        public async Task<CharacterSummary> MapTo(CreateCharacter createCharacter)
        {
            RuleSet ruleSet;
            if (!Enum.TryParse(createCharacter.RuleSet, out ruleSet))
            {
                throw new PPGException($"Could not parse Rule Set {createCharacter.RuleSet}");
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

            var skillMapper = _skillMapperFactory.Resolve(ruleSet);
            var skills = await skillMapper.MapTo(createCharacter.Skills).ConfigureAwait(false);

            var wallets = new Dictionary<string, double>();
            createCharacter.Wallets?.ToList().ForEach(wallet =>
                wallets.Add(wallet.Key, wallet.Value)
            );

            return new CharacterSummary
            {
                CharacterName = createCharacter.CharacterName,
                RuleSet = ruleSet,
                Experience = 0,
                Stats = defaultedStats,
                MetaData = defaultedMetaData,
                Skills = skills,
                Wallets = wallets
            };
        }

        public Task<CreateCharacter> MapFrom(CharacterSummary characterSummary)
        {
            throw new NotImplementedException();
        }

    }
}
