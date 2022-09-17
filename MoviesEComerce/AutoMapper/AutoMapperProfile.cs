using AutoMapper;
using MoviesEComerce.Models;

namespace MoviesEComerce.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ActorEntity, Actor>().ReverseMap();
            CreateMap<ProducerEntity, Producer>().ReverseMap();
            CreateMap<CinemaEntity, Cinema>().ReverseMap();
            CreateMap<MovieEntity,Movie>().ReverseMap();
        }
    }
}
