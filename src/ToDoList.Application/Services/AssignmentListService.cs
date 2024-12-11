using AutoMapper;
using Microsoft.AspNetCore.Http;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    
    private readonly IAssignmentListRepository _assignmentListRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AssignmentListService(IAssignmentListRepository assignmentListRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _assignmentListRepository = assignmentListRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto)
    {
        var assignmentExist = await _assignmentListRepository.GetByNameAndIdAsync(assignmentListDto.Name, assignmentListDto.Id);
        if (assignmentExist != null)
            throw new DomainException("Já existe uma tarefa");
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();

        assignmentList.UserId = GetUserId();
        
        var assignementListCreated = await _assignmentListRepository.CreateAsync(assignmentList);
        return _mapper.Map<AssignmentListDTO>(assignementListCreated);
        
    }

    public async Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto)
    {
        var assignmentListExist = await _assignmentListRepository.GetByIdAsync(assignmentListDto.Id);
        if (assignmentListExist == null)
            throw new DomainException("Não exite nenhuma tarefa com esse Id");
        
        var assignmentList = _mapper.Map<AssignmentList>(assignmentListDto);
        assignmentList.Validate();
        
        assignmentList.UserId = GetUserId();
        var assignmentListUpdated = await _assignmentListRepository.UpdateAsync(assignmentList);
        return _mapper.Map<AssignmentListDTO>(assignmentListUpdated);
    }

    public async Task Delete(int assignmentListId)
    {
        await _assignmentListRepository.RemoveAsync(assignmentListId);
    }

    public async Task<AssignmentListDTO> Get(int assignmentListId)
    {
        var assignmentList = await _assignmentListRepository.GetByIdAsync(assignmentListId);
        return _mapper.Map<AssignmentListDTO>(assignmentList);
    }

    public async Task<List<AssignmentListDTO>> GetAll()
    {
        var allAssignmentLists = await _assignmentListRepository.GetAllAsync();
        return _mapper.Map<List<AssignmentListDTO>>(allAssignmentLists);
    }

    public async Task<AssignmentListDTO> GetByName(string name)
    {
        var assignmentList = await _assignmentListRepository.GetByNameAsync(name);
        return _mapper.Map<AssignmentListDTO>(assignmentList);
    }

    public async Task<List<AssignmentListDTO>> SearchName(string name)
    {
        var assignmentLists = await _assignmentListRepository.SearchByNameAsync(name);
        return _mapper.Map<List<AssignmentListDTO>>(assignmentLists);
    }

    private int GetUserId()
    {
        var claim = _httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "Id");
        if (claim == null)
            throw new DomainException("Usuário inválido");
        return string.IsNullOrEmpty(claim.Value) ? 0 : int.Parse(claim.Value);
    }
}