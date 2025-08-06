// ToDoApp.Core/Models/Category.cs
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core.Models
{
    // Kategori öğesini temsil eden model sınıfı.
    // Veritabanındaki 'Categories' tablosuna karşılık gelir.
    public class Category
    {
        // Kategori ID'si. Otomatik artan bir tam sayı olarak ayarlanacaktır.
        public int ID { get; set; }

        // Kategori adı. Boş bırakılamaz ve maksimum 100 karakter uzunluğunda olabilir.
        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]

        public string Name { get; set; } = string.Empty;

        // Bu kategoriye ait ToDo'ların koleksiyonu (Navigasyon özelliği).
        // Bir kategorinin birden fazla ToDo'su olabilir (One-to-Many ilişki).
        public ICollection<ToDo>? ToDos { get; set; }
    }
}