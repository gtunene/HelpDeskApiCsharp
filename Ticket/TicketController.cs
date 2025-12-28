using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Ticket;

[ApiController]
[Route("api/tickets")]
public class TicketController : ControllerBase
{
    private readonly ITicketService _service;

    public TicketController(ITicketService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        int page = 1,
        int size = 10,
        string? status = null,
        int? userId = null,
        int? categoryId = null,
        int? priorityId = null,
        string? q = null)
    {
        var tickets = await _service.GetAllAsync(page, size, status, userId, categoryId, priorityId, q);
        return Ok(tickets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var ticket = await _service.GetByIdAsync(id);
        if (ticket == null)
        {
            return NotFound();
        }
        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TicketCreateDTO ticketDto)
    {
        var newTicket = await _service.CreateAsync(ticketDto);
        return CreatedAtAction(nameof(GetById), new { id = newTicket.Id }, newTicket);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TicketUpdateDTO ticketDto)
    {
        var updatedTicket = await _service.UpdateAsync(id, ticketDto);
        if (updatedTicket == null)
        {
            return NotFound();
        }
        return Ok(updatedTicket);
    }


    [HttpGet("priority/{priorityId}")]
    public async Task<IActionResult> GetTicketsByPriority(int priorityId)
    {
        var tickets = await _service.GetAllAsync(1, 100, null, null, null, priorityId, null);
        return Ok(tickets);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetTicketsByCategory(int categoryId)
    {
        var tickets = await _service.GetAllAsync(1, 100, null, null, categoryId, null, null);
        return Ok(tickets);
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetTicketsByStatus(string status)
    {
        var tickets = await _service.GetAllAsync(1, 100, status, null, null, null, null);
        return Ok(tickets);
    }

    [HttpGet("/api/users/{userId}/tickets")]
    public async Task<IActionResult> GetTicketsForUser(int userId)
    {
        var tickets = await _service.GetAllAsync(1, 100, null, userId, null, null, null);
        return Ok(tickets);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
