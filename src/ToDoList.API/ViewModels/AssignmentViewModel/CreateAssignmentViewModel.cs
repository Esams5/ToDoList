using System.ComponentModel.DataAnnotations;

namespace ToDoList.API.ViewModels.AssignmentViewModel;

public class CreateAssignmentViewModel
{
    [Required(ErrorMessage = "A descrição não pode ser nula.")]
    [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 5 caracteres.")]
    [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O Id do usuário não pode ser nulo.")]
    public int UserId { get; set; }
    
    [Required(ErrorMessage = "Informe se a tarefa já foi concluída.")]
    public string Concluded { get; set; } = "S";
    
    public int? AssignmentListId { get; set; } = null;
    public DateTime? ConcluedAt { get; set; } = null;
    public DateTime? Deadline { get; set; } = null;
}
