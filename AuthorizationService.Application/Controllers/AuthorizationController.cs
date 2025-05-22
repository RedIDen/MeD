using AuthorizationService.Application.Commands;
using AuthorizationService.Application.Handlers;
using AuthorizationService.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorizationController(
    RegisterUserHandler register,
    LoginUserHandler login) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
    {
        var user = AuthorizationUser.Create(Guid.NewGuid(), dto.Login, dto.Password);
        await register.HandleAsync(new RegisterUserCommand { Login = user.Login, Password = user.Password });
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto dto)
    {
        var token = await login.HandleAsync(new LoginUserCommand { Login = dto.Login, Password = dto.Password });
        return Ok(new { Token = token });
    }
}

public record RegisterUserDto(string Login, string Password);
public record LoginUserDto(string Login, string Password);
