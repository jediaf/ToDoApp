// ToDoApp.Core/Interfaces/ICategoryService.cs
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Core.Interfaces
{
    // Kategori öğeleri için iş mantığı işlemlerini tanımlayan arayüz.
    public interface ICategoryService
    {
        // Tüm kategori öğelerini getirir.
        Task<IEnumerable<Category>> GetAllCategoriesAsync();

        // Belirli bir ID'ye sahip kategori öğesini getirir.
        Task<Category?> GetCategoryByIdAsync(int id);

        // Yeni bir kategori öğesi oluşturur.
        Task<Category> CreateCategoryAsync(Category category);

        // Mevcut bir kategori öğesini günceller.
        Task<bool> UpdateCategoryAsync(int id, Category category); // Güncelleme başarılı olursa true döner

        // Belirli bir kategori öğesini siler.
        Task<bool> DeleteCategoryAsync(int id); // Silme başarılı olursa true döner
    }
}