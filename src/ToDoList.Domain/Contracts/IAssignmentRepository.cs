using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts;

public interface IAssignmentRepository : IBaseRepository<Assignment>
{
    Task<Assignment> GetByIdAsync(int id);
    Task<Assignment> GetByDescriptionAsync(string description);
    Task<List<Assignment>> GetConcluedAsync();

}