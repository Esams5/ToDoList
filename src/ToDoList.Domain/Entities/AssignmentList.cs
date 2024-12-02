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
    }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}