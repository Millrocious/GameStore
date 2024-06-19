using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPublishers()
    {
        
    }
}