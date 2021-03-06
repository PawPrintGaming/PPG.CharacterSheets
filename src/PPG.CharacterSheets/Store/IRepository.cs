﻿using PPG.CharacterSheets.Core;
using System.Linq;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Store
{
    public interface IRepository<TEntity> where TEntity : IIdentifiable
    {
        Task<int> Create(TEntity entity);

        Task<TEntity> Read(int id);
        Task<IQueryable<TEntity>> Read();

        Task<bool> Update(TEntity entity);

        Task<bool> Delete(int id);
    }
}
