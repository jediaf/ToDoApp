// ToDoApp.Core/Interfaces/IToDoService.cs
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Core.Interfaces
{
    // ToDo öğeleri için iş mantığı işlemlerini tanımlayan arayüz.
    public interface IToDoService
    {
        // Tüm ToDo öğelerini getirir (kategorileriyle birlikte).
        Task<IEnumerable<ToDo>> GetAllToDosAsync();

        // Belirli bir ID'ye sahip ToDo öğesini getirir (kategorisiyle birlikte).
        Task<ToDo?> GetToDoByIdAsync(int id);

        // Yeni bir ToDo öğesi oluşturur.
        Task<ToDo> CreateToDoAsync(ToDo todo);

        // Mevcut bir ToDo öğesini günceller.
        Task<bool> UpdateToDoAsync(int id, ToDo todo);

        // Belirli bir ToDo öğesini siler.
        Task<bool> DeleteToDoAsync(int id);
    }
}