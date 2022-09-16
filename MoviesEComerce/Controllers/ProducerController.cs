using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesEComerce.Data;
using MoviesEComerce.Data.Services;
using MoviesEComerce.Models;

namespace MoviesEComerce.Controllers
{

        public class ProducerController : GenericController<ProducerEntity, Producer>
        {

            private readonly IBaseRepository<Producer> _repository;


            public ProducerController(IBaseRepository<Producer> repository, IMapper mapper) : base(repository, mapper)
            {
                _repository = repository;

            }
        }
    
}
