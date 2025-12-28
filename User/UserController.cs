using Microsoft.AspNetCore.Mvc;
using HelpDesk.User;

namespace HelpDesk.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserDTO userDto)
    {
        try
        {
            await _userService.CreateUserAsync(userDto);
            return Ok(new { Message = "User created successfully." });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}