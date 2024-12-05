using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts;

public interface IAssignmentListRepository : IBaseRepository<AssignmentList>
{
    Task<AssignmentList> GetByNameAsync(string name);
    Task<AssignmentList> GetByNameAndIdAsync(string name, int id);
    Task<List<AssignmentList>> SearchByNameAsync(string name);
    
    
}