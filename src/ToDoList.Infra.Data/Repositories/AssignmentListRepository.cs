using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentListRepository : BaseRepository<AssignmentList>, IAssignmentListRepository
{

    private readonly ToDoContext _context;

    public AssignmentListRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<AssignmentList> GetByNameAsync(string name)
    {
        var assignment = await _context.AssignmentLists.Where(
                x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
            .AsNoTracking()
            .ToListAsync();
        
        return assignment.FirstOrDefault();
        
    }

    public async Task<AssignmentList> GetByNameAndIdAsync(string name, int id)
    {
        var assignmnetList = await _context.Set<AssignmentList>()
            .AsNoTracking()
            .Where(x => x.Name == name && x.UserId == id)
            .ToListAsync();

        return assignmnetList.FirstOrDefault();
    }

    public async Task<List<AssignmentList>> SearchByNameAsync(string name)
    {
        var allAssigmentLists = await _context.AssignmentLists.Where
            (
                x => x.Name.ToLower().Contains(name.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();

        return allAssigmentLists;
    }
}