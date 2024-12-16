using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.API.ViewModels;
using ToDoList.API.ViewModels.AssignmentViewModel;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Exceptions;

namespace ToDoList.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssignmentController : ControllerBase
{
    private readonly IAssignmentService _assignmentService;
    private readonly IMapper _mapper;

    public AssignmentController(IAssignmentService assignmentService, IMapper mapper)
    {
        _assignmentService = assignmentService;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpPost]
    [Route("/api/v1/assignment/create")]
    public async Task<IActionResult> Create([FromBody] CreateAssignmentViewModel createAssignmentViewModel)
    {
        try
        {
            var assigmentDto = _mapper.Map<AssignmentDTO>(createAssignmentViewModel);
            var assignmentCreated = await _assignmentService.CreateAssignment(assigmentDto);
            
            return Ok(new ResultViewModel
            {
                Message = "Tarefa criada com sucesso!",
                Success = true,
                Data = assignmentCreated
            });
        }
        catch (DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch (Exception ex)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }
    
    [Authorize]
    [HttpGet]
    [Route("/api/v1/assignment/get-all")]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var allAssignments = await _assignmentService.GetAllAssignments();

            if (allAssignments.Count == 0)
                return Ok(new ResultViewModel
                {
                    Message = "Nenhuma tarefa cadastrada!",
                    Success = true,
                    Data = allAssignments
                });

            return Ok(new ResultViewModel
            {
                Message = "Tarefas encontradas com sucesso!",
                Success = true,
                Data = allAssignments
            });
        }
        catch(DomainException ex)
        {
            return BadRequest(ResultViewModel.DomainErrorMessage(ex.Message, ex.Errors));
        }
        catch(Exception)
        {
            return StatusCode(500, ResultViewModel.ApplicationErrorMessage());
        }
    }
    
    
    
    
    
}