using PPG.CharacterSheets.Store;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Core.Services
{
    public class CRUDService<TEntityType, TModelType> : ICRUDService<TEntityType, TModelType>
        where TEntityType : class, IIdentifiable
        where TModelType : class, IIdentifiable
    {
        private readonly IMapper<TEntityType, TModelType> _mapper;
        private readonly IRepository<TEntityType> _repository;

        public CRUDService(IMapper<TEntityType, TModelType> mapper, IRepository<TEntityType> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<TModelType> Create(TModelType model)
        {
            var entity = await _mapper.MapTo(model).ConfigureAwait(false);
            var id = await _repository.Create(entity).ConfigureAwait(false);
            return await Read(id).ConfigureAwait(false);
        }

        public async Task<TModelType> Read(int id)
        {
            var entity = await _repository.Read(id).ConfigureAwait(false);
            var model = await _mapper.MapFrom(entity).ConfigureAwait(false);
            return model;
        }

        public async Task<IQueryable<TModelType>> Read()
        {
            var entities = await _repository.Read().ConfigureAwait(false);
            var models = entities.Select(entity => _mapper.MapFrom(entity).GetAwaiter().GetResult());
            return models;
        }

        public async Task<TModelType> Update(TModelType model)
        {
            var entity = await _mapper.MapTo(model).ConfigureAwait(false);
            var updatedModel = await _repository.Update(entity).ConfigureAwait(false);
            return model;
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id).ConfigureAwait(false);
        }
    }
}
