// ToDoApp.Infrastructure/Data/ToDoDbContext.cs
using Microsoft.EntityFrameworkCore;
using ToDoApp.Core.Models;

namespace ToDoApp.Infrastructure.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ToDo tablosu yapılandırması
            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                entity.Property(e => e.IsCompleted)
                    .IsRequired()
                    .HasDefaultValue(false);

                // 🔧 SQLite ile uyumlu tarih
                entity.Property(t => t.CreatedAt)
                    .IsRequired()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ToDos)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            // Category tablosu yapılandırması
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Name).IsUnique();

                entity.HasData(
                    new Category { ID = 1, Name = "General" },
                    new Category { ID = 2, Name = "Work" },
                    new Category { ID = 3, Name = "Personal" },
                    new Category { ID = 4, Name = "Shopping" }
                );

            });
        }
    }
}
