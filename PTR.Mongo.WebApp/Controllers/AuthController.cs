using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PTR.Mongo.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private readonly IUserService _userService;

    public AuthController(ITokenService tokenService, IUserService userService)
    {
        _tokenService = tokenService;
        _userService = userService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthenticationRequestDto authDto)
    {
        var user = await _userService.Authenticate(authDto);

        if (user == null) return Unauthorized("Usuario o contraseña incorrectos.");

        var token = _tokenService.GenerateToken(user.RestaurantName);

        return Ok(token);
    }
}