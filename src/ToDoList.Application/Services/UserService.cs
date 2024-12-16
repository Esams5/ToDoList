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
    public async Task<UserDTO> UpdateUserAsync(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByIdAsync(userDto.Id);

        if (userExists == null)
            throw new DomainException("Não existe usuário com o Id informado!");

        var user = _mapper.Map<User>(userDto);
        
        user.Validate();
        user.Password = _passwordHasher.HashPassword(user, user.Password);
        
        var userUpdated = await _userRepository.UpdateAsync(user);

        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task DeleteUserAsync(int id)
    {
        await _userRepository.RemoveAsync(id);
    }

    public async Task<UserDTO> GetUserAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> GetUsersAsync()
    {
        var allUsers = await _userRepository.GetAllAsync();

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetEmailAsync(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> SearchEmailAsync(string email)
    {
        var allUsers = await _userRepository.SearchByEmailAsync(email);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }


    public async Task<UserDTO> CreateUserAsync(UserDTO userDto)
    {
        var userExist = await _userRepository.GetByEmailAsync(userDto.Email);

        if (userExist != null)
            throw new DomainException("O email já está em uso!");

        var user = _mapper.Map<User>(userDto);
        
        user.Validate();
        user.Password = _passwordHasher.HashPassword(user, user.Password);

        var userCreated = await _userRepository.CreateAsync(user);

        return _mapper.Map<UserDTO>(userCreated);;
    }
}