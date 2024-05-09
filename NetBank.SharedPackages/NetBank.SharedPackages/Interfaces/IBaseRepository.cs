using System.Linq.Expressions;

namespace NetBank.SharedPackages.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity?> GetByProp(Expression<Func<TEntity, bool>> SearchingProp);

        Task<TEntity> GetByPropEager(Expression<Func<TEntity, bool>> SearchingProp, params Expression<Func<TEntity, object>>[] includeProperties);

        Task<List<TEntity>> GetAll();

        Task<List<TEntity>> GetAllEager(params Expression<Func<TEntity, object>>[] includeProperties);

        Task<TEntity> Insert(TEntity obj);

        TEntity Update(TEntity obj);

        void Delete(TEntity obj);

        Task SaveChanges();
    }
}
