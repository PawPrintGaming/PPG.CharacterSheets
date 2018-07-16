using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PPG.CharacterSheets.Characters.DTOs;

namespace PPG.CharacterSheets.Characters.Services.Mappers
{
    public class StandardClassMapper : IClassMapper
    {
        public async Task<IEnumerable<CreateClass>> MapFrom(IEnumerable<Class> to)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Class>> MapTo(IEnumerable<CreateClass> from)
        {
            return await Task.Run(() =>
            {
                return from.Select(createClass =>
                    new Class
                    {
                        Name = createClass.Name,
                        Rank = createClass.Rank,
                        MetaData = createClass.MetaData?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
                    }
                );
            });
        }
    }
}
