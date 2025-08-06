// ToDoApp.Core/DTOs/ToDoDto.cs
using System;

namespace ToDoApp.Core.DTOs
{
    // API'den dışarı gönderilecek ToDo verisini temsil eder.
    public class ToDoDto
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; } // Kategori adını doğrudan göndeririz
    }
}