// ToDoApp.Infrastructure/Services/ToDoService.cs
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.Services
{
    // IToDoService arayüzünün somut implementasyonu.
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        // Tüm ToDo öğelerini getirir (kategorileriyle birlikte).
        public async Task<IEnumerable<ToDo>> GetAllToDosAsync()
        {
            return await _toDoRepository.GetAllAsync(); // ✅ Geriye repository'den gelen sonuç döner
        }



        // Belirli bir ID'ye sahip ToDo öğesini getirir (kategorisiyle birlikte).
        public async Task<ToDo?> GetToDoByIdAsync(int id)
        {
            return await _toDoRepository.GetByIdAsync(id);
        }

        // Yeni bir ToDo öğesi oluşturur.
        public async Task<ToDo> CreateToDoAsync(ToDo todo)
        {
            return await _toDoRepository.AddAsync(todo);
        }

        // Mevcut bir ToDo öğesini günceller.
        public async Task<bool> UpdateToDoAsync(int id, ToDo todo)
        {
            if (id != todo.ID)
            {
                return false;
            }

            var existingToDo = await _toDoRepository.GetByIdAsync(id);
            if (existingToDo == null)
            {
                return false;
            }

            existingToDo.Title = todo.Title;
            existingToDo.Description = todo.Description;
            existingToDo.IsCompleted = todo.IsCompleted;
            existingToDo.CategoryId = todo.CategoryId; // Kategori ID'sini de güncelle

            await _toDoRepository.UpdateAsync(existingToDo);
            return true;
        }

        // Belirli bir ToDo öğesini siler.
        public async Task<bool> DeleteToDoAsync(int id)
        {
            var exists = await _toDoRepository.ExistsAsync(id);
            if (!exists)
            {
                return false;
            }

            await _toDoRepository.DeleteAsync(id);
            return true;
        }
    }
}