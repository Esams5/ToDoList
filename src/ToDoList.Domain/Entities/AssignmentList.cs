using ToDoList.Domain.Validators;
using ToDoList.Domain.Exceptions;
namespace ToDoList.Domain.Entities;

public class AssignmentList : Base
{
    public string Name { get; private set; }
    public int UserId { get; private set; }

    public User User { get; private set; }
    public ICollection<Assignment> Assignments { get; private set; }

    public AssignmentList()
    {
        
    }

    public AssignmentList(string name, int userId)
    {
        Name = name;
        UserId = userId;
        Assignments = new List<Assignment>();
        _errors = new List<string>();
        Validate();
    }

    public override bool Validate()
    {
        var validator = new AssignmentListValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);
        }
        throw new DomainException("Alguns campos estão incorretos" + _errors);

        return true;
    }
}