using AutoMapper;
using GameStore.Application.Services.Interfaces;
using GameStore.Data.Repositories;
using GameStore.Domain.Entities;
using GameStore.Domain.Exceptions;
using GameStore.Domain.Interfaces.Repositories;
using GameStore.Dtos.Publisher;

namespace GameStore.Application.Services.Implementations;

public class PublisherService : IPublisherService
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
    {
        _publisherRepository = publisherRepository;
        _mapper = mapper;
    }

    public async Task<PublisherResponseDto> GetPublisherByIdAsync(int id)
    {
        var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
        
        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }
        
        return _mapper.Map<PublisherResponseDto>(publisher);
    }

    public async Task<IList<PublisherResponseDto>> GetAllPublishersAsync()
    {
        var publishers = await _publisherRepository.GetAllPublishersAsync();
        
        return _mapper.Map<IList<PublisherResponseDto>>(publishers);
    }

    public async Task<PublisherResponseDto> AddPublisherAsync(PublisherRequestDto newPublisher)
    {
        var addedPublisher = await _publisherRepository.AddPublisherAsync(_mapper.Map<Publisher>(newPublisher));
        
        return _mapper.Map<PublisherResponseDto>(addedPublisher);
    }

    public async Task UpdatePublisherAsync(int id, PublisherRequestDto updatedPublisher)
    {
        var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
        
        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        _mapper.Map(updatedPublisher, publisher);
        await _publisherRepository.UpdatePublisherAsync(publisher);
    }

    public async Task DeletePublisherAsync(int id)
    {
        var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
        
        if (publisher is null)
        {
            throw new NotFoundException("Publisher not found");
        }

        await _publisherRepository.DeletePublisherAsync(publisher);
    }
}