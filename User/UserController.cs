using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.User;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly IMapper _mapper;


    public UserController(UserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("create")]
    public async Task<IActionResult> Create(UserCreateDTO userCreateDTO)
    {
        try
        {
            await _userService.CreateUserAsync(userCreateDTO);
            return Ok(new { Message = "User created successfully." });
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
            var user = await _userService.GetUserByEmailAsync(userLoginDTO.Email);

            if (user == null)
                return NotFound(new { Error = "User not found." });

            // BEST PRACTICE: Map the User model back to a safe DTO before sending
            var userResponse = _mapper.Map<UserDTO>(user);

            return Ok(userResponse);
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




}



