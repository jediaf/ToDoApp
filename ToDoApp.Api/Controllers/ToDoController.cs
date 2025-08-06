// ToDoApp.Api/Controllers/ToDoController.cs (GÜNCELLENDİ)
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Core.Interfaces;
using ToDoApp.Core.Models;
using ToDoApp.Core.DTOs; // Yeni DTO'lar için
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;
        private readonly ICategoryService _categoryService;

        public ToDoController(IToDoService toDoService, ICategoryService categoryService)
        {
            _toDoService = toDoService;
            _categoryService = categoryService;
        }

        // GET: /api/todo -> Tüm görevleri DTO olarak getirir
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoDto>>> GetAll()
        {
            var todos = await _toDoService.GetAllToDosAsync();
            
            // Veri tabanı modelini DTO'ya dönüştürür
            var todoDtos = todos.Select(t => new ToDoDto
            {
                ID = t.ID,
                Title = t.Title,
                Description = t.Description,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
                CategoryId = t.CategoryId,
                CategoryName = t.Category?.Name // Kategori varsa adını al
            });

            return Ok(todoDtos);
        }

        // GET: /api/todo/{id} -> Spesifik bir görevi DTO olarak getirir
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoDto>> GetById(int id)
        {
            var todo = await _toDoService.GetToDoByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            var todoDto = new ToDoDto
            {
                ID = todo.ID,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt,
                CategoryId = todo.CategoryId,
                CategoryName = todo.Category?.Name
            };

            return Ok(todoDto);
        }

        // POST: /api/todo -> Yeni görev ekler, DTO kullanır
        [HttpPost]
        public async Task<ActionResult<ToDoDto>> Create(CreateToDoDto createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (createDto.CategoryId.HasValue)
            {
                var categoryExists = await _categoryService.GetCategoryByIdAsync(createDto.CategoryId.Value);
                if (categoryExists == null)
                {
                    ModelState.AddModelError("CategoryId", "The specified category was not found.");
                    return BadRequest(ModelState);
                }
            }
            
            // DTO'dan veritabanı modeline dönüştür
            var todo = new ToDo
            {
                Title = createDto.Title,
                Description = createDto.Description,
                IsCompleted = createDto.IsCompleted,
                CategoryId = createDto.CategoryId
            };

            var createdTodo = await _toDoService.CreateToDoAsync(todo);

            var todoDto = new ToDoDto
            {
                ID = createdTodo.ID,
                Title = createdTodo.Title,
                Description = createdTodo.Description,
                IsCompleted = createdTodo.IsCompleted,
                CreatedAt = createdTodo.CreatedAt,
                CategoryId = createdTodo.CategoryId
            };
            // ToDo'nun kategori adı yok, o yüzden onu atlama

            return CreatedAtAction(nameof(GetById), new { id = todoDto.ID }, todoDto);
        }

        // PUT: /api/todo/{id} -> Mevcut bir görevi günceller, DTO kullanır
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateToDoDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            if (updateDto.CategoryId.HasValue)
            {
                var categoryExists = await _categoryService.GetCategoryByIdAsync(updateDto.CategoryId.Value);
                if (categoryExists == null)
                {
                    ModelState.AddModelError("CategoryId", "The specified category was not found.");
                    return BadRequest(ModelState);
                }
            }

            // DTO'dan veritabanı modeline dönüştür
            var todo = new ToDo
            {
                ID = id,
                Title = updateDto.Title,
                Description = updateDto.Description,
                IsCompleted = updateDto.IsCompleted,
                CategoryId = updateDto.CategoryId
            };
            
            var result = await _toDoService.UpdateToDoAsync(id, todo);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: /api/todo/{id} -> Belirtilen görevi siler
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _toDoService.DeleteToDoAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}