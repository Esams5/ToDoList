using ToDoList.Domain.Validators;
using ToDoList.Domain.Exceptions;

namespace ToDoList.Domain.Entities
{
    public class User : Base
    {
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }

        public User()
        {
            
        }

        public User(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;
            _errors = new List<string>();

            Validate();

        }

        public void ChangeName(string name)
        {
            Name = name;
            Validate();
        }

        public void ChangeEmail(string email)
        {
            Email = email;
            Validate();
        }

        public void ChangePassword(string password)
        {
            Password = password;
            Validate();
        }
        

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                    
                }
                
                throw new DomainException("Validation Failed", _errors);
                
            }

            return true;
        }
    }
}

