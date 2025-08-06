// ToDoApp.Core/Models/ToDo.cs
using System;
using System.ComponentModel.DataAnnotations; // DataAnnotations için
using System.ComponentModel.DataAnnotations.Schema; // Column attribute'ü için

namespace ToDoApp.Core.Models
{
    // ToDo öğesini temsil eden model sınıfı.
    // Veritabanındaki 'ToDos' tablosuna karşılık gelir.
    public class ToDo
    {
        // Görev ID'si. Otomatik artan bir tam sayı olarak ayarlanacaktır.
        // Entity Framework Core, 'ID' ismindeki int tipindeki property'yi varsayılan olarak Primary Key ve Identity olarak algılar.
        public int ID { get; set; }

        // Görev başlığı. Boş bırakılamaz ve maksimum 100 karakter uzunluğunda olabilir.
        [Required(ErrorMessage = "Title is required.")] // Başlık boş bırakılamaz
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")] // Başlık uzunluk kısıtlaması
        public string Title { get; set; } = string.Empty; // Nullable referans tipleri için varsayılan değer

        // Görev açıklaması. Boş bırakılabilir ve maksimum 500 karakter uzunluğunda olabilir.
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")] // Açıklama uzunluk kısıtlaması
        public string? Description { get; set; } // Nullable olabilir

        // Görevin tamamlanma durumu. Varsayılan olarak 'false' (tamamlanmamış) ayarlanır.
        public bool IsCompleted { get; set; } = false;

        // Görevin oluşturulma tarihi.
        // Bu alanın değeri veritabanı tarafından otomatik olarak atanacaktır (DEFAULT GETDATE()).
        // C# tarafında DateTime.Now atamasına gerek yoktur, çünkü veritabanı bu değeri yönetecek.
        public DateTime CreatedAt { get; set; }

        // Görevin ait olduğu kategori ID'si (Foreign Key).
        // Bu alan boş bırakılabilir, yani bir ToDo'nun kategorisi olmayabilir.
        public int? CategoryId { get; set; }

        // Kategori navigasyon özelliği.
        // Bir ToDo'nun ait olduğu Category nesnesine erişim sağlar.
        // Foreign Key ilişkisini temsil eder.
        public Category? Category { get; set; }
    }
}