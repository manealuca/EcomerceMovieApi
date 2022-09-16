using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;

namespace MoviesEComerce.Controllers
{
    public  abstract class GenericController<Model,Entity> : Controller where Entity : class where Model: Models.EntityBase, new()
    {

        private readonly IBaseRepository<Entity> _repository;
        private readonly IMapper _mapper;

        protected GenericController(IBaseRepository<Entity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var Model = await _repository.GetAllAsync();
            return View(Model);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Model model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();

                return View(model);
            }
            Entity entity;
            try
            {
                //entity = _mapper.Map<Entity>(model);
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                await _repository.AddAsync(_mapper.Map<Entity>(model));
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
                when(ex.InnerException is SqlException sqlEx &&(sqlEx.Number==2601 || sqlEx.Number==2627))
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Registro duplicado");
            }catch(Exception e)
            {
                return Conflict(e.Message);
            }

        }
        //Actor/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var editActor = await _repository.GetByIdAsync(id);
            if (editActor is null) return View("NotFound");
            return View(editActor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Entity model)
        {
            if (!ModelState.IsValid) return View(model);

            await _repository.UpdateAsync(id, model);
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
        public async Task<IActionResult> Detail(int id)
        {
            var actorDetail = await _repository.GetByIdAsync(id);
            if (actorDetail is null) return View("NotFound");

            return View(actorDetail);
        }
        //Actor/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var deleteModel = await _repository.GetByIdAsync(id);
            if (deleteModel is null) return View("NotFound");
            return View(deleteModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleteModel = await _repository.GetByIdAsync(id);
            if (deleteModel is null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }


    }
}

