using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;

namespace ToDoList.Application.Services;

public class AssignmentListService : IAssignmentListService
{
    public Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto)
    {
        throw new NotImplementedException();
    }

    public Task Delete(int assignmentListId)
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentListDTO> Get(int assignmentListId)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentListDTO>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<AssignmentListDTO> GetByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<AssignmentListDTO>> SearchName(string name)
    {
        throw new NotImplementedException();
    }
}