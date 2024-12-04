namespace ToDoList.Application.DTO;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string password { get; set; }

    public UserDTO()
    {
        
    }

    public UserDTO(int id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        this.password = password;
    }
}