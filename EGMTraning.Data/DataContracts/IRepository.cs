using System.Linq.Expressions;

namespace EGMTraning.Data.DataContracts
{
    public  interface IRepository<T> where T: class, new()
    {
        Task<T> GetByIdAsync(int id);

        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

    }
}
