// ToDoApp.Infrastructure/Services/CategoryService.cs
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Infrastructure.Services
{
    // ICategoryService arayüzünün somut implementasyonu.
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            // İş mantığı veya doğrulama kuralları burada eklenebilir.
            return await _categoryRepository.AddAsync(category);
        }

        public async Task<bool> UpdateCategoryAsync(int id, Category category)
        {
            if (id != category.ID)
            {
                return false;
            }

            var existingCategory = await _categoryRepository.GetByIdAsync(id);
            if (existingCategory == null)
            {
                return false;
            }

            existingCategory.Name = category.Name;

            await _categoryRepository.UpdateAsync(existingCategory);
            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var exists = await _categoryRepository.ExistsAsync(id);
            if (!exists)
            {
                return false;
            }

            await _categoryRepository.DeleteAsync(id);
            return true;
        }
    }
}