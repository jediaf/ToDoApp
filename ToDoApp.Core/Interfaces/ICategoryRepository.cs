// ToDoApp.Core/Interfaces/ICategoryRepository.cs
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Core.Interfaces
{
    // Kategori öğeleri için veri erişim işlemlerini tanımlayan arayüz.
    public interface ICategoryRepository
    {
        // Tüm kategori öğelerini asenkron olarak getirir.
        Task<IEnumerable<Category>> GetAllAsync();

        // Belirli bir ID'ye sahip kategori öğesini asenkron olarak getirir.
        Task<Category?> GetByIdAsync(int id); // Category? null dönebileceğini belirtir

        // Yeni bir kategori öğesi ekler ve asenkron olarak kaydeder.
        Task<Category> AddAsync(Category category);

        // Mevcut bir kategori öğesini günceller ve asenkron olarak kaydeder.
        Task UpdateAsync(Category category);

        // Belirli bir ID'ye sahip kategori öğesini asenkron olarak siler.
        Task DeleteAsync(int id);

        // Belirli bir ID'ye sahip kategori öğesinin var olup olmadığını kontrol eder.
        Task<bool> ExistsAsync(int id);
    }
}