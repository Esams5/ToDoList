using ToDoList.Domain.Entities;
namespace ToDoList.Domain.Contracts;

public interface IBaseRepository<T> where T : Base
{
    Task<T> CreateAsync(T obj);
    Task<T> UpdateAsync(T obj);
    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task RemoveAsync(int id);

}