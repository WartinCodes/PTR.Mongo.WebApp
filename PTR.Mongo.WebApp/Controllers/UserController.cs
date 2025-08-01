using PTR.Mongo.WebApp.Models.Dtos.Requests;
using PTR.Mongo.WebApp.Models.Dtos.Responses;
using PTR.Mongo.WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PTR.Mongo.WebApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        if (user is null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create(CreateUserRequestDto request)
    {
        UserResponseDto? newUser = _userService.CreateUser(request);
        return Ok(newUser);
    }

    [HttpDelete]
    public IActionResult DeleteUser(int id)
    {
        _userService.DeleteUser(id);
        return Ok();
    }
}
