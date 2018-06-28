using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.ErrorHandling;

namespace PPG.CharacterSheets.Characters.Services
{
    public class CharacterPolymorphService : ICharacterPolymorphService
    {
        public async Task<CharacterSummary> UpdatePropertyByName(CharacterSummary characterSummary, string propName, object value)
        {
            var propertyInfo = typeof(CharacterSummary).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new PPGException($"Could not find property {propName} on Character Summary");
            }
            if (!propertyInfo.CanWrite)
            {
                throw new PPGException($"Property {propName} on Character Summary is read only");
            }
            try
            {
                var castValue = Convert.ChangeType(value, propertyInfo.PropertyType);
                propertyInfo.SetValue(characterSummary, value);
                return characterSummary;
            }
            catch (InvalidCastException)
            {
                throw new PPGException($"Cannot assign {value} to property {propName} of Type {propertyInfo.PropertyType.Name} on Character Summary");
            }
        }

        public async Task<CharacterSummary> UpdateStatByName(CharacterSummary characterSummary, string statName, object value)
        {
            return await Task.Run(() =>
            {
                if (!int.TryParse(value.ToString(), out int castValue))
                {
                    throw new PPGException($"Cannot convert {value} of type {value.GetType().Name} to an integer, not suitable for updating Character Summary Stat");
                }
                if (characterSummary.Stats.ContainsKey(statName))
                {
                    characterSummary.Stats[statName] = castValue;
                }
                else
                {
                    characterSummary.Stats.Add(statName, castValue);
                }
                return characterSummary;
            });
        }

        public async Task<CharacterSummary> UpsertSkillByName(CharacterSummary characterSummary, Skill skill)
        {
            return await Task.Run(() =>
            {
                if (characterSummary.Skills.Any(existingSkill => existingSkill.Name.Equals(skill.Name)))
                {
                    var skillToUpdate = characterSummary.Skills.Single(existingSkill => existingSkill.Name.Equals(skill.Name));
                    skillToUpdate.Rank = skill.Rank;
                    skillToUpdate.MetaData = skill.MetaData;
                }
                else
                {
                    var skills = characterSummary.Skills.ToList();
                    skills.Add(skill);
                    characterSummary.Skills = skills;
                }
                return characterSummary;
            });
        }

        public async Task<CharacterSummary> UpdateSkillRank(CharacterSummary characterSummary, string skillName, object rank)
        {
            return await Task.Run(() =>
            {
                if (characterSummary.Skills.Any(skill => skill.Name.Equals(skillName)))
                {
                    if (!int.TryParse(rank.ToString(), out int castValue))
                    {
                        throw new PPGException($"Cannot convert {rank} of type {rank.GetType().Name} to an integer, not suitable for updating Character Skill Rank");
                    }
                    var skillToUpdate = characterSummary.Skills.First(skill => skill.Name.Equals(skillName));
                    skillToUpdate.Rank = castValue;
                }
                return characterSummary;
            });
        }

        public async Task<CharacterSummary> UpdateMetaData(CharacterSummary characterSummary, string dataKey, string value)
        {
            return await Task.Run(() =>
            {
                if (characterSummary.MetaData.ContainsKey(dataKey))
                {
                    characterSummary.MetaData[dataKey] = value;
                }
                else
                {
                    characterSummary.MetaData.Add(dataKey, value);
                }
                return characterSummary;
            });
        }

        public async Task<CharacterSummary> UpdateSkillTriggerDescription(CharacterSummary characterSummary, string skillName, string triggerName, string updatedDescription)
        {
            return await Task.Run(() =>
            {
                if (characterSummary.Skills.Any(someSkill => someSkill.Name.Equals(skillName)))
                {
                    var skill = characterSummary.Skills.First(skillToUpdate => skillToUpdate.Name.Equals(skillName));
                    if (skill.MetaData["triggers"] != null && skill.MetaData["triggers"].ContainsKey(triggerName))
                    {
                        if (skill.MetaData["triggers"][triggerName].ContainsKey("description"))
                        {
                            skill.MetaData["triggers"][triggerName]["description"] = updatedDescription;
                        }
                    }
                }
                return characterSummary;
            });
        }

        public async Task<CharacterSummary> DeleteSkillTrigger(CharacterSummary characterSummary, string skillName, string triggerName)
        {
            return await Task.Run(() =>
            {
                if (characterSummary.Skills.Any(skill => skill.Name.Equals(skillName)))
                {
                    var skill = characterSummary.Skills.First(skillToUpdate => skillToUpdate.Name.Equals(skillName));
                    if(skill.MetaData["triggers"] != null && skill.MetaData["triggers"].ContainsKey(triggerName))
                    {
                        skill.MetaData["triggers"].Remove(triggerName);
                    }
                }
                return characterSummary;
            });
        }
    }
}
