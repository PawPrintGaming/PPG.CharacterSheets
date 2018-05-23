using Microsoft.AspNetCore.Mvc;
using PPG.CharacterSheets.Core.Requests;
using PPG.CharacterSheets.Core.Services;
using System;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Core.Controllers
{
    public abstract class RESTfulCRUDController<TEntity, TCreateType, TModelType> : Controller
        where TEntity : class, IIdentifiable 
        where TCreateType : class
        where TModelType : class, IIdentifiable
    {
        private readonly ICRUDService<TEntity, TModelType> _service;

        protected abstract Func<TCreateType, Task<TModelType>> CreateModelHandler { get; }

        public RESTfulCRUDController(ICRUDService<TEntity, TModelType> service)
        {
            _service = service;
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> Create([FromBody] PayloadRequest<TCreateType> request)
        {
            var modelToCreate = await CreateModelHandler(request.Payload).ConfigureAwait(false);
            var createdEntity = await _service.Create(modelToCreate).ConfigureAwait(false);
            return Ok(createdEntity);
        }

        [HttpGet, Route("{id}")]
        public async Task<IActionResult> Read(int id)
        {
            var entity = await _service.Read(id).ConfigureAwait(false);
            return entity == null
                ? NotFound() as IActionResult
                : Ok(entity) as IActionResult;
        }

        [HttpPut, Route("")]
        public async Task<IActionResult> Update([FromBody] PayloadRequest<TModelType> request)
        {
            await _service.Update(request.Payload).ConfigureAwait(false);
            return Ok();
        }

        [HttpDelete, Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id).ConfigureAwait(false);
            return Ok();
        }
    }
}
