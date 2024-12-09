using ToDoList.Application.DTO;


namespace ToDoList.Application.Interfaces;

public interface IAssignmentService
{
    Task<AssignmentDTO> CreateAssignment(AssignmentDTO assignmentDto);
    Task<AssignmentDTO> UpdateAssignment(AssignmentDTO assignmentDto);
    Task RemoveAssignment(int assignmentId);
    Task<AssignmentDTO> GetAssignment(int assignmentId);
    Task<List<AssignmentDTO>> GetAllAssignments();
    Task<List<AssignmentDTO>> GetConluded();
    Task<AssignmentDTO> GetDescription(string description);
    
}