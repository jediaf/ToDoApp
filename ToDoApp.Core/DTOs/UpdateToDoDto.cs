// ToDoApp.Core/DTOs/UpdateToDoDto.cs
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.DTOs
{
    // API'ye mevcut bir ToDo güncellenirken kullanılacak veri.
    public class UpdateToDoDto
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