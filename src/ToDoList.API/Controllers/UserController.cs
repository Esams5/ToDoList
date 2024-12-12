using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.ViewModels;
using ToDoList.API.ViewModels.UserViewModel;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;

namespace ToDoList.API.Controllers;

[Route("ap1/v1/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    [Route("/api/users/create")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<User>(userViewModel);
            var userCreated = await _userService.CreateUserAsync(userDto);
            return Ok(new ResultViewModel
            {
                Message = "User Created",
                Success = true,
                Data = userCreated
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }

    [Authorize]
    [HttpPut]
    [Route("/api/v1/users/update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserViewModel userViewModel)
    {
        try
        {
            var userDto = _mapper.Map<User>(userViewModel);
            var userUpdate = await _userService.UpdateUserAsync(userDto);
            return Ok(new ResultViewModel
            {
                Message = "User Updated",
                Success = true,
                Data = userUpdate
            });
        }

        catch (DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }

    [Authorize]
    [HttpDelete]
    [Route("/api/v1/users/remove{id}")]
    public async Task<IActionResult> Remove(int id)
    {
        try
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return Ok(new ResultViewModel
                {
                    Message = "User Not Found",
                    Success = false,
                    Data = user

                });
            await _userService.DeleteUserAsync(id);
            return Ok(new ResultViewModel
            {
                Message = "User Removed",
                Success = true,
                Data = null
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }

    [Authorize]
    [HttpGet]
    [Route("/api/v1/users/get/{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            var user = await _userService.GetUserAsync(id);

            if (user == null)
                return Ok(new ResultViewModel
                {
                    Message = "User Not Found",
                    Success = false,
                    Data = user
                });
            return Ok(new ResultViewModel
            {
                Message = "User Retrieved",
                Success = true,
                Data = user
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }
    
    
}