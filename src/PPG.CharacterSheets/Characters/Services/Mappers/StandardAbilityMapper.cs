using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public class StandardAbilityMapper : IAbilityMapper
    {
        public Task<IEnumerable<Ability>> MapTo(IEnumerable<CreateAbility> from)
        {
           return Task.Run(() => {
               return from.ToList().Select(createAbility =>
                new Ability {
                    Name = createAbility.Name,
                    Description = createAbility.Description,
                    MetaData = createAbility.MetaData.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                }
               );
            });
        }

        public async Task<IEnumerable<CreateAbility>> MapFrom(IEnumerable<Ability> to)
        {
            throw new NotImplementedException();
        }
    }
}
