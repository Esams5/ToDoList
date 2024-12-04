using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Contracts;

public interface IUserRepository : IBaseRepository<User>
{
    
    Task<User> GetByEmailAsync(string email);
    Task<List<User>> SearchByEmailAsync(string email);
    
}