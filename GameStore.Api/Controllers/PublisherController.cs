using GameStore.Application.Dtos.Publisher;
using GameStore.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[ApiController]
[Route("api/publishers")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<ActionResult<IList<PublisherResponseDto>>> GetAll()
    {
        var publishers = await _publisherService.GetAllPublishersAsync();
        
        return Ok(publishers);
    }
    
    [HttpGet("{id:int:min(1)}")]
    public async Task<ActionResult<PublisherResponseDto>> GetById([FromRoute] int id)
    {
        var publisher = await _publisherService.GetPublisherByIdAsync(id);

        return Ok(publisher);
    }
    
    [HttpPost]
    public async Task<ActionResult<PublisherResponseDto>> Add([FromBody] PublisherRequestDto publisherDto)
    {
        var publisher = await _publisherService.AddPublisherAsync(publisherDto);

        return Created(nameof(Add), publisher);
    }
    
    [HttpPut("{id:int:min(1)}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] PublisherRequestDto publisherDto)
    {
        await _publisherService.UpdatePublisherAsync(id, publisherDto);
        
        return NoContent();
    }
    
    [HttpDelete("{id:int:min(1)}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _publisherService.DeletePublisherAsync(id);

        return NoContent();
    }
}