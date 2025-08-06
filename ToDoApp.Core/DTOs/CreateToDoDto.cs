// ToDoApp.Core/DTOs/CreateToDoDto.cs
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.DTOs
{
    // API'ye yeni bir ToDo eklenirken kullanılacak veri.
    public class CreateToDoDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Description { get; set; }
        
        public bool IsCompleted { get; set; }
        public int? CategoryId { get; set; }
    }
}