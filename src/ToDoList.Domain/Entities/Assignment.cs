using System.Runtime.InteropServices.JavaScript;
using ToDoList.Domain.Exceptions;
using ToDoList.Domain.Validators;

namespace ToDoList.Domain.Entities;

public class Assignment : Base
{
    public int UserId { get; private set; }
    public int? AssignmentListId { get; private set; }
    public string Description { get; private set; }
    public string Concluded { get; private set; }
    public DateTime? ConcluedAt { get; private set; }
    public DateTime? Deadline { get; private set; }
    
    public User User { get; private set; }
    public AssignmentList AssignmentList { get; private set; }

    public Assignment()
    {
        
    }

    public Assignment(int userId, string description, string concluded)
    {
        UserId = userId;
        Description = description;
        Concluded = concluded;
        _errors = new List<string>();
        Validate();
    }


    public override bool Validate()
    {
        var validator = new AssignmentValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach(var error in validation.Errors)
                _errors.Add(error.ErrorMessage);
        }
        throw new DomainException("Alguns campos incorretos." + _errors);

        return true;
    }
}