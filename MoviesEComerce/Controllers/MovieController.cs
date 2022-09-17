using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;

namespace MoviesEComerce.Controllers
{
    public class MovieController : GenericController<MovieEntity, Movie>
    {

        private readonly IBaseRepository<Movie> _repository;


        public MovieController(IBaseRepository<Movie> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;

        }

    }
}
