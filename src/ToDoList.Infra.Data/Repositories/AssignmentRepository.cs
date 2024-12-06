using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data;
using ToDoList.Infra.Data.Context;


namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{

    private readonly ToDoContext _context;

    public AssignmentRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Assignment> GetByDescriptionAsync(string description)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Assignment>> GetConcluedAsync()
    {
        throw new NotImplementedException();
    }
}