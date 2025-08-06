// ToDoApp.Core/Interfaces/IToDoRepository.cs
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Core.Interfaces
{
    // ToDo öğeleri için veri erişim işlemlerini tanımlayan arayüz.
    public interface IToDoRepository
    {
        // Tüm ToDo öğelerini asenkron olarak getirir (kategorileriyle birlikte).
        Task<IEnumerable<ToDo>> GetAllAsync();

        // Belirli bir ID'ye sahip ToDo öğesini asenkron olarak getirir (kategorisiyle birlikte).
        Task<ToDo?> GetByIdAsync(int id);

        // Yeni bir ToDo öğesi ekler ve asenkron olarak kaydeder.
        Task<ToDo> AddAsync(ToDo todo);

        // Mevcut bir ToDo öğesini günceller ve asenkron olarak kaydeder.
        Task UpdateAsync(ToDo todo);

        // Belirli bir ID'ye sahip ToDo öğesini asenkron olarak siler.
        Task DeleteAsync(int id);

        // Belirli bir ID'ye sahip ToDo öğesinin var olup olmadığını kontrol eder.
        Task<bool> ExistsAsync(int id);
    }
}