namespace ToDoList.Application.DTO;

public class AssignmentDTO
{
    public int  UserId { get; set; }
    public int Id { get; set; }
    public string Description { get; set; }
    public int AssignmentListId { get; set; }

    public string Concluded { get; set; }
    public DateTime ConcluedAt { get; set; }
    public DateTime Deadline { get; set; }

    public AssignmentDTO()
    {
        
    }

    public AssignmentDTO(int userId, int id, string description, int assignmentListId, string concluded, DateTime concluedAt, DateTime deadline)
    {
        UserId = userId;
        Id = id;
        Description = description;
        AssignmentListId = assignmentListId;
        Concluded = concluded;
        ConcluedAt = concluedAt;
        Deadline = deadline;
    }
}