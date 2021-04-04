namespace Data.Repositories.Contracts
{
    using Core.Helpers;
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<TEntity> : IDisposable
        where TEntity : class
    {
        IQueryable<TEntity> All();

        Task<TEntity> GetByIdAsync(params object[] id);

        IQueryable<TEntity> AllAsNoTracking();

        Task AddAsync(TEntity entity);

        TEntity Update(TEntity entity);

        void Delete(TEntity entity);

        Task<OperationResult> SaveChangesAsync();


        // Custom
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate);
        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
