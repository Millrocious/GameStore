using AutoMapper;
using GameStore.Application.Dtos.Publisher;
using GameStore.Domain.Entities;

namespace GameStore.Application.AutoMapperProfiles;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        CreateMap<Publisher, PublisherRequestDto>()
            .ReverseMap()
            .ForMember(o => o.Id, opt => opt.Ignore());
        
        CreateMap<Publisher, PublisherResponseDto>();
    }
}