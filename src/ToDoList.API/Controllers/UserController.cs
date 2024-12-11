using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;

namespace ToDoList.API.Controllers;

[Route("ap1/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    
    
}