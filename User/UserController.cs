using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.User;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;


    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }


    [HttpGet]
    public async Task<IActionResult> GetUsers(int page = 1, int size = 10, string? search = null)
    {
        try
        {
            var users = await _userService.GetAllUsersAsync(page, size, search);
            return Ok(users);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Error = "User not found." });
            }
            return Ok(user);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }


    [HttpPost] // Changed from [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody]UserCreateRequest userCreateRequest)
    {
        try
        {
            var createdUser = await _userService.CreateUserAsync(userCreateRequest);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
    {
        try
        {
            var user = await _userService.LoginAsync(userLoginDTO);

            if (user == null)
                return Unauthorized(new { Error = "Invalid email or password." });

            var userResponse = _mapper.Map<UserResponseDTO>(user);

            return Ok(userResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _userService.DeleteUserAsync(id);
            return NoContent(); // 204 No Content as per spec
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody]UserUpdateRequest userUpdateRequest)
    {
        try
        {
            var updatedUser = await _userService.UpdateUserAsync(id, userUpdateRequest);
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
