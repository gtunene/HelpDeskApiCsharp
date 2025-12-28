using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.TicketPriority;

[ApiController]
[Route("api/priorities")]
public class TicketPriorityController : ControllerBase
{
    private readonly ITicketPriorityService _service;

    public TicketPriorityController(ITicketPriorityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var priorities = await _service.GetAllAsync();
        return Ok(priorities);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TicketPriorityCreateUpdateDTO priorityDto)
    {
        var updatedPriority = await _service.UpdateAsync(id, priorityDto);
        if (updatedPriority == null)
        {
            return NotFound();
        }
        return Ok(updatedPriority);
    }
}
