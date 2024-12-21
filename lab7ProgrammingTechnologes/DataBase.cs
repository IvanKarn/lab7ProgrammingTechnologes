using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7ProgrammingTechnologes
{
    [Table("Categories")]
    public class Category
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new();
    }

    [Table("Products")]
    public class Product
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Price")]
        public int Price { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    // Контекст базы данных
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Укажите свои данные для подключения
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Дополнительная настройка сущностей
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(u => u.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
