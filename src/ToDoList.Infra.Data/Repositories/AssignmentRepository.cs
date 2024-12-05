using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data;
using ToDoList.Infra.Data.Context;


namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{
    public AssignmentRepository(ToDoContext context) : base(context)
    {
    }

    public Task<Assignment> GetByDescriptionAsync(string description)
    {
        throw new NotImplementedException();
    }

    public Task<List<Assignment>> GetConcluedAsync()
    {
        throw new NotImplementedException();
    }
}