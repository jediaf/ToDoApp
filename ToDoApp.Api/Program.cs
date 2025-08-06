using Microsoft.EntityFrameworkCore;
using ToDoApp.Infrastructure.Data;
using ToDoApp.Core.Interfaces;
using ToDoApp.Infrastructure.Repositories;
using ToDoApp.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://0.0.0.0:8080");

// Servisleri ekle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Veritabanı yapılandırması
builder.Services.AddDbContext<ToDoDbContext>(options =>
    options.UseSqlite("Data Source=/data/todo.db"));


// DI (Dependency Injection)
builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
builder.Services.AddScoped<IToDoService, ToDoService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Otomatik Migration (tablo eksik hataları engellemek için)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ToDoDbContext>();
    db.Database.Migrate();
}

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS aktif et
app.UseRouting();
app.UseCors("AllowAll");

// HTTPS yönlendirme kaldırıldı çünkü container HTTPS portuna bağlı değil
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
