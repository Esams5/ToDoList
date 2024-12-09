using ToDoList.Application.DTO;
namespace ToDoList.Application.Interfaces;

public interface IAssignmentListService
{
    Task<AssignmentListDTO> Create(AssignmentListDTO assignmentListDto);
    Task<AssignmentListDTO> Update(AssignmentListDTO assignmentListDto);
    Task Delete(int assignmentListId);
    Task<AssignmentListDTO> Get(int assignmentListId);
    Task<List<AssignmentListDTO>> GetAll();
    Task<AssignmentListDTO> GetByName(string name);
    Task<List<AssignmentListDTO>> SearchName(string name);
}