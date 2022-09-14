using MoviesEComerce.Models;
using System.Linq.Expressions;

namespace MoviesEComerce.Data.Services
{
    public interface IBaseRepository<T> : IDisposable where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        Task<T> Search(Expression<Func<T, bool>> expression);
    }
}
