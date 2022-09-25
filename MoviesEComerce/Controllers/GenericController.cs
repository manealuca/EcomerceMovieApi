using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;
using Newtonsoft.Json;

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
                 _repository.AddAsync(_mapper.Map<Entity>(model));
                
                if (model is MovieEntity)
                {
                    
                    await using (var db = new MovieComerceContext())
                    {
                        var movie = _mapper.Map<MovieEntity>(model);
                        var movies = db.Movie.Where(m => m.MovieName == movie.MovieName && m.MovieCategory == movie.MovieCategory && m.ProducerId == movie.ProducerId && m.MovieImageUrl == movie.MovieImageUrl).FirstOrDefault();
                        List<MovieActor> ActorList = new List<MovieActor>();
                        foreach (var id in movie.ActorIds)
                        {
                            var newActorMovie = new MovieActor()
                            {
                                MovieId = movies.Id,
                                ActorId = id
                            };
                            ActorList.Add(newActorMovie);

                        }
                        db.MovieActor.AddRange(ActorList);
                        db.SaveChanges();
                    }


                }


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

            if(model is Movie)
            {
                Movie aux = JsonConvert.DeserializeObject<Movie>(JsonConvert.SerializeObject(model));


                using (var db = new MovieComerceContext())
            {
               
                var movieEdit = await db.Movie.Include(c => c.cinema).Include(p => p.MovieProducer).Include(am => am.MovieActors).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
                    movieEdit.MovieImageUrl = aux.MovieImageUrl;
                    movieEdit.MovieName = aux.MovieName;
                    movieEdit.MovieCategory=aux.MovieCategory;
                    movieEdit.cinema = aux.cinema;
                    movieEdit.Price=aux.Price;
                    movieEdit.ProducerId=aux.ProducerId;
                    movieEdit.CinemaId = aux.CinemaId;
                    movieEdit.EndDate=aux.EndDate;
                    movieEdit.StartDate = aux.StartDate;
                    movieEdit.MovieActors=aux.MovieActors;
                    movieEdit.MovieDescription = aux.MovieDescription;
                    movieEdit.MovieProducer = aux.MovieProducer;
                    movieEdit.cinema = aux.cinema;

                    model = _mapper.Map<Entity>(movieEdit);
                    await _repository.UpdateAsync(id, model);
                    return RedirectToAction(nameof(Index));
            }   
            }
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

            if(actorDetail is Movie)
            {
                using (var db = new MovieComerceContext())
                {
                    var movieDetail = await db.Movie.Include(c => c.cinema).Include(p => p.MovieProducer).Include(am => am.MovieActors).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
                    if (movieDetail is null) return View("NotFound");

                    return View(movieDetail);
                }
            }
            return View(actorDetail);
        }
        //Actor/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var deleteModel = await _repository.GetByIdAsync(id);
            if (deleteModel is null) return View("NotFound");
            if (deleteModel is Movie)
            {
                using (var db = new MovieComerceContext())
                {
                    var movieDelete = await db.Movie.Include(c => c.cinema).Include(p => p.MovieProducer).Include(am => am.MovieActors).ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
                    if (movieDelete is null) return View("NotFound");

                    return View(movieDelete);
                }
            }
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

