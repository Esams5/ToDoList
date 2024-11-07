using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u)
                .NotEmpty()
                .WithMessage("User name cannot be empty")
                .NotNull()
                .WithMessage("User name cannot be null");
            
            RuleFor(u => u.Name)
                .NotEmpty()
                .WithMessage("Name cannot be empty")
                
                .NotNull()
                .WithMessage("Name cannot be null")
                
                .MinimumLength(3)
                .MaximumLength(100)
                .WithMessage("Name must be between 3 and 100 characters");
            
            RuleFor(u => u.Email)
                .NotEmpty()
                .WithMessage("Email is required")

                .NotNull()
                .WithMessage("Email is required")

                .MinimumLength(3)
                .MaximumLength(180)
                .WithMessage("Email must be between 3 and 180 characters")

                .EmailAddress()
                .WithMessage("Invalid email address")
            
                .Matches(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
                .WithMessage("Email format is invalid");

                

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("Password is required")

                .NotNull()
                .WithMessage("Password is required")
                
                .MinimumLength(6)
                .MaximumLength(30)
                .WithMessage("Password must be between 6 and 30 characters")
                
                .Matches(@"[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]")
                .WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d")
                .WithMessage("Password must contain at least one number")
                .Matches(@"[\W_]")
                .WithMessage("Password must contain at least one special character");
        }
    
    }
}

