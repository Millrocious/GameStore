using AutoMapper;
using GameStore.Application.Dtos.Game;
using GameStore.Domain.Entities;

namespace GameStore.Application.AutoMapperProfiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<Game, GameRequestDto>()
            .ReverseMap()
            .ForMember(o => o.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre))
            .ForMember(dest => dest.Publisher, opt => opt.Ignore());

        CreateMap<Game, GameResponseDto>();
    }
}