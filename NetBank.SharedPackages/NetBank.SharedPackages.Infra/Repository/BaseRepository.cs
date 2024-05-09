using Microsoft.EntityFrameworkCore;
using NetBank.SharedPackages.Interfaces;
using System.Linq.Expressions;

namespace NetBank.SharedPackagesInfra.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TEntity?> GetByProp(Expression<Func<TEntity, bool>> SearchingProp) 
        {
            return await _context.Set<TEntity>().SingleOrDefaultAsync(SearchingProp);
        }

        public async Task<TEntity> GetByPropEager(Expression<Func<TEntity, bool>> SearchingProp, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.SingleOrDefaultAsync(SearchingProp);
        }


        public async Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllEager(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> Insert(TEntity obj) 
        {
            var insertEntry = await _context.Set<TEntity>().AddAsync(obj);
            return insertEntry.Entity;
        }

        public TEntity Update(TEntity obj)
        {
            var updateEntry = _context.Set<TEntity>().Update(obj);
            return updateEntry.Entity;
        }

        public void Delete(TEntity obj)
        {
            var removeEntry = _context.Set<TEntity>().Remove(obj);
        }

        public async Task SaveChanges() 
        {
            await _context.SaveChangesAsync();
        }
    }
}
