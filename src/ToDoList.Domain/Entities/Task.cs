namespace ToDoList.Domain.Entities
{
    public class Task
    {
        public string Descripton { get; set; } = null!;
        public int UserId { get; set; }
        public int? AssignmentListId { get; set; }

    }
}

