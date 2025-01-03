using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class AssignmentListRepository : BaseRepository<AssignmentList>, IAssignmentListRepository
{

    private readonly  ToDoContext _context;
    
    public AssignmentListRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public virtual async Task<AssignmentList> GetByName(string name)
    {
        var assigmentList = await _context.AssignmentLists.Where
            (
                x => x.Name.ToLower().Contains(name.ToLower())
            )
            .AsNoTracking()
            .ToListAsync();

        return assigmentList.FirstOrDefault();
    }

    
    public async Task<AssignmentList> GetByNameAndId(string name, int userId)
    {
        var assignmentList = await _context.Set<AssignmentList>()
            .AsNoTracking()
            .Where(x => x.Name == name && x.UserId == userId)
            .ToListAsync();

        return assignmentList.FirstOrDefault();
    }

    public virtual async Task<List<AssignmentList>> SearchByName(string name)
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