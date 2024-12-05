using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Data.Context;

namespace ToDoList.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : Base
{
    private readonly ToDoContext _context;

    public BaseRepository(ToDoContext context)
    {
        _context = context;
        
    }
    
    public async Task<T> CreateAsync(T obj)
    {
        _context.Add(obj);
        await _context.SaveChangesAsync();
        return obj;
    }

    public async Task<T> UpdateAsync(T obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return obj;
    }

    public async Task<T> GetByIdAsync(int id)
    {
        var obj = await _context.Set<T>()
            .AsNoTracking()
            .Where(x => x.Id == id)
            .ToListAsync();
        return obj.FirstOrDefault();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>()
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task RemoveAsync(int id)
    {
        var obj = await GetByIdAsync(id);
        _context.Remove(obj);
        await _context.SaveChangesAsync();
    }
}