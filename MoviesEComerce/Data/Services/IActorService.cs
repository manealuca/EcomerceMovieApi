using MoviesEComerce.Models;

namespace MoviesEComerce.Data.Services
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor oActor);
        Task<Actor> UpdateAsync(int id, Actor oActor);
        Task DeleteAsync(int id);

    }
}
