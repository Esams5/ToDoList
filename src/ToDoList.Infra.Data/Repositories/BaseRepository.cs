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
        throw new NotImplementedException();
    }

    public async Task<T> UpdateAsync(T obj)
    {
        throw new NotImplementedException();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task RemoveAsync(int id)
    {
        throw new NotImplementedException();
    }
}