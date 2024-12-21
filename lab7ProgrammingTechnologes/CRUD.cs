using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab7ProgrammingTechnologes;
using Microsoft.EntityFrameworkCore;

namespace lab7ProgrammingTechnologes
{
    internal static class CRUD
    {
        static AppDbContext context = new AppDbContext();
        static public void Itit()
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
        public static void AddCategories(IEnumerable<string> categories)
        {
            context.Categories.AddRange((from i in categories select new Category { Name = i }));
            context.SaveChanges();
        }
        public static void AddProducts(IEnumerable<Product> products)
        {
            context.Products.AddRange(products);
            context.SaveChanges();
        }
        public static void UpdateCategory(int Id, Category newCategory)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                category.Name = newCategory.Name;
            }
            context.SaveChanges();
        }
        public static void UpdateProduct(int Id, Product newProduct)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == Id);
            if (product != null)
            {
                product.Name = newProduct.Name;
                product.Category = newProduct.Category;
                product.Price = newProduct.Price;
            }
            context.SaveChanges();
        }
        public static void DeleteProduct(int Id)
        {
            var product = context.Products.FirstOrDefault(c => c.Id == Id);
            if (product != null)
            {
                context.Products.Remove(product);
            }
            context.SaveChanges();
        }
        public static void DeleteCategory(int Id)
        {
            var category = context.Categories.FirstOrDefault(c => c.Id == Id);
            if (category != null)
            {
                context.Categories.Remove(category);
            }
            context.SaveChanges();
        }
        public static List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public static List<Product> GetProducts()
        {
            return context.Products.ToList();
        }
        public static List<Product>? GetProducts(int category)
        {
            return context.Categories.Include(c => c.Products).FirstOrDefault(c => c.Id == category )?.Products;
        }
    }
}
