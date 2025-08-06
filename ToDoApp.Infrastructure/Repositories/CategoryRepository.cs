// ToDoApp.Infrastructure/Repositories/CategoryRepository.cs
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Infrastructure.Data; // DbContext'i kullanmak için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.Repositories
{
    // ICategoryRepository arayüzünün somut implementasyonu.
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ToDoDbContext _context;

        // Bağımlılık Enjeksiyonu ile DbContext'i alır.
        public CategoryRepository(ToDoDbContext context)
        {
            _context = context;
        }

        // Tüm kategori öğelerini asenkron olarak getirir.
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        // Belirli bir ID'ye sahip kategori öğesini asenkron olarak getirir.
        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        // Yeni bir kategori öğesi ekler ve asenkron olarak kaydeder.
        public async Task<Category> AddAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        // Mevcut bir kategori öğesini günceller ve asenkron olarak kaydeder.
        public async Task UpdateAsync(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Belirli bir ID'ye sahip kategori öğesini asenkron olarak siler.
        public async Task DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        // Belirli bir ID'ye sahip kategori öğesinin var olup olmadığını kontrol eder.
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Categories.AnyAsync(e => e.ID == id);
        }
    }
}