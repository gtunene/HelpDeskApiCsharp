using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.TicketCategory;

[ApiController]
[Route("api/categories")]
public class TicketCategoryController : ControllerBase
{
    private readonly TicketCategoryService _service;

    public TicketCategoryController(TicketCategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _service.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await _service.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TicketCategoryCreateUpdateDTO categoryDto)
    {
        var newCategory = await _service.CreateAsync(categoryDto);
        return CreatedAtAction(nameof(GetById), new { id = newCategory.Id }, newCategory);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TicketCategoryCreateUpdateDTO categoryDto)
    {
        var updatedCategory = await _service.UpdateAsync(id, categoryDto);
        if (updatedCategory == null)
        {
            return NotFound();
        }
        return Ok(updatedCategory);
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