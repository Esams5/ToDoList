using ToDoList.Application.DTO;

namespace ToDoList.Application.Interfaces;

public interface IUserService
{
    Task<UserDTO> CreateUserAsync(UserDTO user);
    Task<UserDTO> UpdateUserAsync(UserDTO user);
    Task<UserDTO> DeleteUserAsync(int userid);
    Task<UserDTO> GetUserAsync(int userid);
    Task<List<UserDTO>> GetUsersAsync();
    Task<UserDTO> GetEmailAsync(string email);
    Task<UserDTO> SearchEmailAsync(string username);
    
}