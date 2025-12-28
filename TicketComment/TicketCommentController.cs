using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.TicketComment;

[ApiController]
[Route("api")] // Base route to handle both /api/tickets/{id}/comments and /api/comments/{id}
public class TicketCommentController : ControllerBase
{
    private readonly ITicketCommentService _service;

    public TicketCommentController(ITicketCommentService service)
    {
        _service = service;
    }

    [HttpGet("tickets/{ticketId}/comments")]
    public async Task<IActionResult> GetCommentsForTicket(int ticketId)
    {
        var comments = await _service.GetCommentsForTicketAsync(ticketId);
        return Ok(comments);
    }

    [HttpPost("tickets/{ticketId}/comments")]
    public async Task<IActionResult> CreateCommentForTicket(int ticketId, TicketCommentCreateDTO commentDto)
    {
        var newComment = await _service.CreateAsync(ticketId, commentDto);
        return CreatedAtAction(nameof(GetCommentsForTicket), new { ticketId = ticketId }, newComment);
    }

    [HttpDelete("comments/{id}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var success = await _service.DeleteAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}
