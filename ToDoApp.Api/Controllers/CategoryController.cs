// ToDoApp.Api/Controllers/CategoryController.cs
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Api.Controllers
{
    // Bu sınıfın bir API controller olduğunu belirtir.
    [ApiController]
    // Bu controller'ın temel rota önekini belirler (örn: /api/category).
    [Route("api/[controller]")] // Rota: /api/category
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: /api/category
        // Tüm kategorileri getirir.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: /api/category/{id}
        // Belirli bir ID'ye sahip kategoriyi getirir.
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: /api/category
        // Yeni bir kategori oluşturur.
        [HttpPost]
        public async Task<ActionResult<Category>> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = createdCategory.ID }, createdCategory);
        }

        // PUT: /api/category/{id}
        // Mevcut bir kategoriyi günceller.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _categoryService.UpdateCategoryAsync(id, category);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: /api/category/{id}
        // Belirtilen ID'ye sahip kategoriyi siler.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}