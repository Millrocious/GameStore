using GameStore.Application.Dtos.Publisher;

namespace GameStore.Application.Services.Interfaces;

public interface IPublisherService
{
    Task<PublisherResponseDto> GetPublisherByIdAsync(int id);
    Task<IList<PublisherResponseDto>> GetAllPublishersAsync();
    Task<PublisherResponseDto> AddPublisherAsync(PublisherRequestDto newPublisher);
    Task UpdatePublisherAsync(int id, PublisherRequestDto updatedPublisher);
    Task DeletePublisherAsync(int id);
}