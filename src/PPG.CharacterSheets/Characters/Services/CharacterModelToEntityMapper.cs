﻿using Newtonsoft.Json;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Services
{
    public class CharacterModelToEntityMapper : IMapper<Character, CharacterSummary>
    {
        public async Task<CharacterSummary> MapFrom(Character character)
        {
            
            return character == null
                ? null
                : new CharacterSummary
                {
                    Id = character.Id,
                    CharacterName = character.CharacterName,
                    RuleSet = character.RuleSet,
                    Experience = character.Experience,
                    Stats = JsonConvert.DeserializeObject<Dictionary<string, int>>(character.Stats),
                    MetaData = JsonConvert.DeserializeObject<Dictionary<string, string>>(character.MetaData)
                };

        }

        public async Task<Character> MapTo(CharacterSummary characterSummary)
        {
            return characterSummary == null
                ? null
                : new Character
                {
                    Id = characterSummary.Id,
                    CharacterName = characterSummary.CharacterName,
                    RuleSet = characterSummary.RuleSet,
                    Experience = characterSummary.Experience,
                    Stats = JsonConvert.SerializeObject(characterSummary.Stats),
                    MetaData = JsonConvert.SerializeObject(characterSummary.MetaData)
                };
        }
    }
}