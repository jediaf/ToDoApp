// ToDoApp.Infrastructure/Data/ToDoDbContextFactory.cs
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ToDoApp.Infrastructure.Data
{
    // Bu sınıf, Entity Framework Core tasarım zamanı araçlarının (dotnet ef)
    // ToDoDbContext'i nasıl oluşturacağını belirtir.
    // Özellikle DbContext'in farklı bir projede olduğu durumlarda gereklidir.
    public class ToDoDbContextFactory : IDesignTimeDbContextFactory<ToDoDbContext>
    {
        public ToDoDbContext CreateDbContext(string[] args)
        {
            // appsettings.json dosyasını bulmak ve yapılandırmayı yüklemek için bir yapılandırma oluşturur.
            // Bu, migrasyonların doğru bağlantı dizesini kullanmasını sağlar.
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ToDoApp.Api")) // API projesinin yolunu belirtir
                .AddJsonFile("appsettings.json")
                .Build();

            // DbContextOptionsBuilder kullanarak veritabanı bağlantı seçeneklerini yapılandırır.
            var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Eğer bağlantı dizesi bulunamazsa bir hata fırlatır.
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("DefaultConnection connection string not found in appsettings.json.");
            }

            // SQL Server'ı kullanmak üzere yapılandırır.
            optionsBuilder.UseSqlite(connectionString);

            // Yapılandırılmış seçeneklerle ToDoDbContext'in yeni bir örneğini döndürür.
            return new ToDoDbContext(optionsBuilder.Options);
        }
    }
}