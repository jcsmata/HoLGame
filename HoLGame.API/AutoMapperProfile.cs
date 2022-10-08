using AutoMapper;
using HoLGame.MODELS;
using HoLGame.SERVICES;

namespace HoLGame.API
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<GameModel, Game>().ReverseMap();
            CreateMap<PlayerModel, Player>().ReverseMap();
        }
    }
}
