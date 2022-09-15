using AutoMapper;
using MoviesEComerce.Models;

namespace MoviesEComerce.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ActorEntity, Actor>().ReverseMap();
        }
    }
}
