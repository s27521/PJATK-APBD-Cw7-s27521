using Microsoft.AspNetCore.Mvc;
using PJATK_APBD_Cw7_s27521.Service;

namespace PJATK_APBD_Cw7_s27521.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PCsController(IPCService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add()
    {
        return Ok();
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id)
    {
        return Ok();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok();
    }
}