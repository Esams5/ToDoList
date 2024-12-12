using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ToDoList.Application.DTO;
using ToDoList.Application.Interfaces;
using ToDoList.Domain.Contracts;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher<User> _passwordHasher;

    public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHasher<User> passwordHasher)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
    }


    public async Task<UserDTO> CreateUserAsync(User userDto)
    {
        var exist = await _userRepository.GetByEmailAsync(userDto.Email);

        if (exist != null)
            throw new DomainException("O email está em uso");
        var user = _mapper.Map<User>(userDto);
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        user.Validate();
        
        var userCreated = await _userRepository.CreateAsync(user);
        
        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> UpdateUserAsync(User userDto)
    {
        var exist = await _userRepository.GetByIdAsync(userDto.Id);

        if (exist == null)
            throw new DomainException("Não existe esse Id");
        var user = _mapper.Map<User>(userDto);
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        user.Validate();
        
        var userUpdated = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task DeleteUserAsync(int userid)
    {
        await _userRepository.RemoveAsync(userid);
    }

    public async Task<UserDTO> GetUserAsync(int userid)
    {
        var user = await _userRepository.GetByIdAsync(userid);
        
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<List<UserDTO>>(users);
    }

    public async Task<UserDTO> GetEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> SearchEmailAsync(string username)
    {
        var users = await _userRepository.SearchByEmailAsync(username);
        return _mapper.Map<List<UserDTO>>(users);
    }
}