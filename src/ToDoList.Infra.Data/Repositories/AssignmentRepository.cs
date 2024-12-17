using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;

using ToDoList.Infra.Data.Context;


namespace ToDoList.Infra.Data.Repositories;

public class AssignmentRepository : BaseRepository<Assignment>, IAssignmentRepository
{

    private readonly ToDoContext _context;

    public AssignmentRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Assignment> GetByIdAsync(int id, int userId)
    {
        var assigment = await _context.Set<Assignment>().Where(
                x => x.Id == id && x.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
        return assigment.FirstOrDefault();
    }

    public async Task<Assignment> GetByDescriptionAsync(string description)
    {
        var assignmentdescription = await _context.Set<Assignment>().AsNoTracking().Where(
                x => x.Description == description)
            .ToListAsync();
        return assignmentdescription.FirstOrDefault();
    }

    public async Task<List<Assignment>> GetConcluedAsync()
    {
        return await _context.Assignments.Where(
            x => x.Concluded == "S")
            .AsNoTracking()
            .ToListAsync();
    }
}