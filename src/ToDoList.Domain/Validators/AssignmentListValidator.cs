using FluentValidation;
using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Validators;

public class AssignmentListValidator : AbstractValidator<AssignmentList>
{
    public AssignmentListValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id vazio ou nulo");
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome vazio ou nulo")
            
            .MinimumLength(3)
            .WithMessage("O nome dever ter no mínimo 3 caracteres")
            
            .MaximumLength(50)
            .WithMessage("O nome deve ter no máximo 50 caracteres");
    }
    
}