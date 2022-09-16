using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;

namespace MoviesEComerce.Controllers
{
    public class CinemaController : GenericController<CinemaEntity, Cinema>
    {
        private readonly IBaseRepository<Cinema> _repository;


        public CinemaController(IBaseRepository<Cinema> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;

        }
    }
}
