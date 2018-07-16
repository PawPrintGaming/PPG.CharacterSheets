using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Services.Builders;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public class StandardSkillMapper : ISkillMapper
    {
        public async Task<IEnumerable<CreateSkill>> MapFrom(IEnumerable<Skill> to)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Skill>> MapTo(IEnumerable<CreateSkill> from)
        {
            return await Task.Run(() =>
            {
                return from.Select(createSkill =>
                    new Skill
                    {
                        Name = createSkill.Name,
                        Rank = createSkill.Rank,
                        MetaData = createSkill.MetaData?.ToDictionary(
                            kvpA => kvpA.Key,
                            kvpA => kvpA.Value?.ToDictionary(
                                kvpB => kvpB.Key,
                                kvpB => kvpB.Value?.ToDictionary(
                                    kvpC => kvpC.Key,
                                    kvpC => kvpC.Value
                                )
                            )
                        )
                    }
                );
            });
        }
    }
}
