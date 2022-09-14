using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Models;

namespace MoviesEComerce.Data.Services
{
    public class ActorService : IActorService
    {
        private  readonly MovieComerceContext _context;
        public ActorService(MovieComerceContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor oActor)
        {

            _context.AddAsync(oActor);
            _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(a => a.ActorId == id);
            _context.Actor.Remove(result);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Actor>>GetAllAsync()
        {
            
                var result = await _context.Actor.ToListAsync();
                if (result is null)
                    throw new NotImplementedException();
                return result;
            
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actor.FirstOrDefaultAsync(a => a.ActorId == id);
            if (result is null) return null;
            return result;
        }

        public async Task <Actor>UpdateAsync(int id, Actor oActor)
        {
            oActor.ActorId = id;
            _context.Update(oActor);
            _context.SaveChanges();
            return oActor;
        }
    }
}
