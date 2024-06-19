using AutoMapper;
using GameStore.Domain.Entities;
using GameStore.Dtos.Publisher;

namespace GameStore.Application.AutoMapperProfiles;

public class PublisherProfile : Profile
{
    public PublisherProfile()
    {
        // Mapping for Publisher <-> PublisherRequestDto
        CreateMap<Publisher, PublisherRequestDto>()
            .ReverseMap()
            .ForMember(o => o.Id, opt => opt.Ignore());
        
        // Mapping for Publisher <-> PublisherResponseDto
        CreateMap<Publisher, PublisherResponseDto>();
    }
}