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
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<PublisherResponseDto>> GetPublisher([FromRoute] int id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);

        return Ok(publisher);
    }
    
    [HttpPost]
    public async Task<ActionResult> CreatePublisher([FromBody] PublisherRequestDto publisherDto)
    {
        var publisher = await _publisherService.AddPublisherAsync(publisherDto);

        return Ok(publisher);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult> UpdatePublisher([FromRoute] int id, [FromBody] PublisherRequestDto publisherDto)
    {
        await _publisherService.UpdatePublisherAsync(id, publisherDto);
        
        return NoContent();
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> DeletePublisher([FromRoute] int id)
    {
        await _publisherService.DeletePublisherAsync(id);

        return NoContent();
    }
}