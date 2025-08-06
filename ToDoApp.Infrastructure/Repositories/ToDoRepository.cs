// ToDoApp.Infrastructure/Repositories/ToDoRepository.cs
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.Repositories
{
    // IToDoRepository arayüzünün somut implementasyonu.
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        // Tüm ToDo öğelerini asenkron olarak getirir.
        // Kategori bilgilerini de dahil etmek için Include metodu kullanılır.
        public async Task<IEnumerable<ToDo>> GetAllAsync()
        {
            return await _context.ToDos
                    .Include(t => t.Category) // Category navigasyon özelliğini dahil et
                    .ToListAsync();
        }

        // Belirli bir ID'ye sahip ToDo öğesini asenkron olarak getirir.
        // Kategori bilgilerini de dahil etmek için Include metodu kullanılır.
        public async Task<ToDo?> GetByIdAsync(int id)
        {
            return await _context.ToDos
                                 .Include(t => t.Category) // Category navigasyon özelliğini dahil et
                                 .FirstOrDefaultAsync(t => t.ID == id); // FindAsync Include ile çalışmaz
        }

        // Yeni bir ToDo öğesi ekler ve asenkron olarak kaydeder.
        public async Task<ToDo> AddAsync(ToDo todo)
        {
            _context.ToDos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        // Mevcut bir ToDo öğesini günceller ve asenkron olarak kaydeder.
        public async Task UpdateAsync(ToDo todo)
        {
            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Belirli bir ID'ye sahip ToDo öğesini asenkron olarak siler.
        public async Task DeleteAsync(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        // Belirli bir ID'ye sahip ToDo öğesinin var olup olmadığını kontrol eder.
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.ToDos.AnyAsync(e => e.ID == id);
        }
    }
}