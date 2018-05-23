using Microsoft.AspNetCore.Mvc;
using PPG.CharacterSheets.Characters.DTOs;
using PPG.CharacterSheets.Characters.Entities;
using PPG.CharacterSheets.Core.Controllers;
using PPG.CharacterSheets.Core.Services;
using System;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Characters.Controllers
{
    [Route("/api/characters")]
    public class CharacterController : RESTfulCRUDController<Character, CreateCharacter, CharacterSummary>
    {
        private readonly IMapper<CharacterSummary, CreateCharacter> _mapper;

        public CharacterController(ICRUDService<Character, CharacterSummary> service, IMapper<CharacterSummary, CreateCharacter> mapper)
            : base(service)
        {
            _mapper = mapper;
        }

        protected override Func<CreateCharacter, Task<CharacterSummary>> CreateModelHandler => async (createCharacter) => await _mapper.MapTo(createCharacter);
    }
}