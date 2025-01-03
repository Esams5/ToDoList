using ToDoList.Application.DTO;
namespace ToDoList.Application.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDTO> CreateAsync(AssignmentListDTO assignmentListDto);
    Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto);
    Task Remove(int id);
    Task<AssignmentListDTO> Get(int id);
    Task<List<AssignmentListDTO>> GetAll();
    Task<AssignmentListDTO> GetByName(string name);
    Task<List<AssignmentListDTO>> SearchByName(string name);
}