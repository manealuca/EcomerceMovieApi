using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;


namespace MoviesEComerce.Controllers
{
    public class ActorController : GenericController<ActorEntity, Actor>
    {

        private readonly IBaseRepository<Actor> _repository;


        public ActorController(IBaseRepository<Actor> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;

        } 
    }
}
        /*public  async Task<IActionResult> Index()
        {
            var Actores = await _repository.GetAllAsync();
            return View(Actores);   
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(include:"ProfilePictureURL,FullName,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
             await _repository.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }
        //Actor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var editActor = await _repository.GetByIdAsync(id);
            if (editActor is null) return View("NotFound");
            return View(editActor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if(!ModelState.IsValid) return View(actor);

            await _repository.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));

        }
        /*
        public async  Task <IActionResult> AttachConfirmed([Bind(include: "ProfilePictureURL,FullName,Bio,ActorId")] Actor oActor)
        {
            var entity = new Actor { ActorId = oActor.ActorId,
                                      FullName=oActor.FullName,
                                        Bio=oActor.Bio,
                                        ProfilePictureURL = oActor.ProfilePictureURL
            };
            if (ModelState.IsValid)
            {
                try
                {
                    if (entity.ActorId >0)
                    {
                        var Actor = await _repository.Search(a=>a.FullName==oActor.FullName && a.ProfilePictureURL == oActor.ProfilePictureURL && a.ActorId!=oActor.ActorId);
                        if (Actor is null) return BadRequest("Ya Existe un registro con el mismo nombre y foto de perfil");

                        _repository.UpdateAsync(Actor.ActorId, Actor);
                    }
                    else
                    {
                        var Actor = await _repository.Search(a => a.FullName == oActor.FullName);
                        if (Actor is null) return BadRequest("Ya Existe un registro con el mismo nombre");
                        _repository.AddAsync(Actor);
                    }
                    
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return View(entity);
        }*/
       /* public async Task<IActionResult> Detail(int id)
        {
            var actorDetail = await _repository.GetByIdAsync(id);
            if(actorDetail is null) return View("NotFound");
 
            return View(actorDetail);
        }
        //Actor/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var deleteActor = await _repository.GetByIdAsync(id);
            if (deleteActor is null) return View("NotFound");
            return View(deleteActor);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteActor = await _repository.GetByIdAsync(id);
            if (deleteActor is null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}*/
