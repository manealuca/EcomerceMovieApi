using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoviesEComerce.Models;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MoviesEComerce.Data.Services
{
    public class EntityBaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MovieComerceContext _context;
        public EntityBaseRepository(MovieComerceContext context)
        {
            _context = context;
        }

        protected DbSet<T> EntitySet
        {
            get { return _context.Set<T>(); }
        }
        public Task AddAsync(T entity)
        {
          
            EntitySet.Add(entity);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {

            /*var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
            */
            T entity = await EntitySet.FindAsync(id);
            EntitySet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task UpdateAsync(int id, T entity)
        {
            /*EntityEntry entityEntry = _context.Entry(entity);
            entityEntry.State = EntityState.Modified;
           */
            EntitySet.Update(entity);
            _context.SaveChanges();
            return Task.CompletedTask;

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {

            var result = await EntitySet.ToListAsync();
            if (result is null)
                return Enumerable.Empty<T>();
            return result;

        }

        public async Task<T> GetByIdAsync(int id)
        {
            var result = await EntitySet.FindAsync(id);
            if (result is null) return null;
            return result;
        }

        public void Dispose()
        {
            //Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<T> Search(Expression<Func<T,bool>> expression)
        {
            return await EntitySet.AsNoTracking().FirstOrDefaultAsync(expression);
            
        }

    }
}
