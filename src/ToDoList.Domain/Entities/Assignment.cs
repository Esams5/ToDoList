namespace ToDoList.Domain.Entities;

public class Assignment : Base
{
    public int UserId { get; private set; }
    public int AssignmentListId { get; private set; }
    public string Description { get; private set; }
    public string Concluded { get; private set; }
    public DateTime ConcluedAt { get; private set; }
    public DateTime Deadline { get; private set; }
    
    public User User { get; private set; }
    
    
    
    
    
    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}