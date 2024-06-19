using GameStore.Dtos.Publisher;

namespace GameStore.Application.Services.Interfaces;

public interface IPublisherService
{
    Task<PublisherResponseDto?> GetPublisherByIdAsync(Guid id);
    Task<IList<PublisherResponseDto>> GetAllPublishersAsync();
    Task<PublisherResponseDto> AddPublisherAsync(PublisherRequestDto newPublisher);
    Task UpdatePublisherAsync(Guid id, PublisherRequestDto updatedPublisher);
    Task DeletePublisherAsync(Guid id);
}