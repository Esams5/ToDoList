using AutoMapper;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Application.Services;

public class AssignmentServices : IAssignmentService
{
    private readonly IAssignmentRepository _repository;
    private readonly IMapper _mapper;

    public AssignmentServices(IAssignmentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<AssignmentDTO> CreateAssignment(AssignmentDTO assignmentDto)
    {
        var exist = await _repository.GetByDescriptionAsync(assignmentDto.Description);
        
        if(exist != null)
            throw new DomainException("Já existe uma tarefa cadastrada com essa descrição");
        
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();
        
        var assignmentCreated = await _repository.CreateAsync(assignment);
        
        return _mapper.Map<AssignmentDTO>(assignmentCreated);
    }

    public async Task<AssignmentDTO> UpdateAssignment(AssignmentDTO assignmentDto)
    {
        var exist = await _repository.GetByDescriptionAsync(assignmentDto.Description);
        
        if(exist != null)
            throw new DomainException("Já existe uma tarefa cadastrada com essa descrição");
        
        var assignment = _mapper.Map<Assignment>(assignmentDto);
        assignment.Validate();
        
        var assignmentUpdated = await _repository.UpdateAsync(assignment);
        return _mapper.Map<AssignmentDTO>(assignmentUpdated);
    }

    public async Task RemoveAssignment(int assignmentId)
    {
        await _repository.RemoveAsync(assignmentId);
    }

    public async Task<AssignmentDTO> GetAssignment(int assignmentId)
    {
        var assignment = await _repository.GetByIdAsync(assignmentId);

        if (assignment == null)
            throw new DomainException("Não foi encontrado nada relacionado ao Id");
        
        return _mapper.Map<AssignmentDTO>(assignment);
    }

    public async Task<List<AssignmentDTO>> GetAllAssignments()
    {
        var allAssignments = await _repository.GetAllAsync();
        return _mapper.Map<List<AssignmentDTO>>(allAssignments);
    }

    public async Task<List<AssignmentDTO>> GetConluded()
    {
        var concluedAssignments = await _repository.GetConcluedAsync();
        return _mapper.Map<List<AssignmentDTO>>(concluedAssignments);
        
    }

    public async Task<AssignmentDTO> GetDescription(string description)
    {
        var assignmentDescription = await _repository.GetByDescriptionAsync(description);

        if (assignmentDescription == null)
            throw new DomainException("Não existe nenhuma tarefa com essa descrição");
        return _mapper.Map<AssignmentDTO>(assignmentDescription);
    }
}