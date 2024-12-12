using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{

    private readonly ToDoContext _context;

    public UserRepository(ToDoContext context) : base(context)
    {
        _context = context;
    }

    

    public async Task<User?> GetByEmailAsync(string email)
    {
        var user = await _context.Users.Where(u => u.Email == email)
            .AsNoTracking()
            .ToListAsync();
        return user.FirstOrDefault();
    }

    public async Task<List<User>> SearchByEmailAsync(string email)
    {
        var users = await _context.Users.Where(u => u.Email == email)
            .AsNoTracking()
            .ToListAsync();
        return users;
    }
}