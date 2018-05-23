﻿using PPG.CharacterSheets.Core;
using System.Threading.Tasks;

namespace PPG.CharacterSheets.Store
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IIdentifiable
    {
        private readonly Context<TEntity> _context;

        public Repository(Context<TEntity> context)
        {
            _context = context;
        }

        public async Task<int> Create(TEntity entity)
        {
            _context.EntitySet.Add(entity);
            _context.SaveChanges();
            return entity.Id;
        }

        public async Task<TEntity> Read(int id)
        {
            var entity = _context.EntitySet.Find(id);
            return entity;
        }

        public async Task<bool> Update(TEntity entity)
        {
            _context.EntitySet.Update(entity);
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Read(id).ConfigureAwait(false);
            _context.EntitySet.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}
