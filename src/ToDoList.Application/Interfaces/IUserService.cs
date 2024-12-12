using ToDoList.Application.DTO;
using ToDoList.Domain.Entities;

namespace ToDoList.Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> CreateUserAsync(User user);
    Task<UserDTO> UpdateUserAsync(User user);
    Task DeleteUserAsync(int userid);
    Task<UserDTO> GetUserAsync(int userid);
    Task<List<UserDTO>> GetUsersAsync();
    Task<UserDTO> GetEmailAsync(string email);
    Task<List<UserDTO>> SearchEmailAsync(string username);
    
}