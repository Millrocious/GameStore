using GameStore.Application.Services.Interfaces;
using GameStore.Dtos.Publisher;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<PublisherResponseDto>>> GetPublishers()
    {
        var publishers = await _publisherService.GetAllPublishersAsync();
        
        return Ok(publishers);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherResponseDto>> GetPublisher(Guid id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);

        return Ok(publisher);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreatePublisher(PublisherRequestDto publisherDto)
    {
        var publisher = await _publisherService.AddPublisherAsync(publisherDto);

        return Ok(publisher);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePublisher(Guid id, PublisherRequestDto publisherDto)
    {
        await _publisherService.UpdatePublisherAsync(id, publisherDto);
        
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePublisher(Guid id)
    {
        await _publisherService.DeletePublisherAsync(id);

        return NoContent();
    }
}