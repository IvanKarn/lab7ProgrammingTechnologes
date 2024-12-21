using System.ComponentModel.DataAnnotations.Schema;
using lab7ProgrammingTechnologes;
using Microsoft.EntityFrameworkCore;
namespace ConsoleApp1;



public class Program
{
    public static void Main(string[] args)
    {
        CRUD.Itit();
        CRUD.AddCategories(new List<string>{"Bike", "Lamp"});
        var p = new List<Product> { new Product { Name = "Bike1", Price = 10, CategoryId = (from i in CRUD.GetCategories() where i.Name == "Bike" select i.Id).First() },
            new Product { Name = "Bike2", Price = 30, CategoryId = (from i in CRUD.GetCategories() where i.Name == "Bike" select i.Id).First() },
            new Product { Name = "Lamp1", Price = 10, CategoryId = (from i in CRUD.GetCategories() where i.Name == "Lamp" select i.Id).First() } };
        CRUD.AddProducts(p);
        CRUD.GetProducts().ForEach(p => Console.WriteLine("Name: {0}  Category: {1}",p.Name, p.Category.Name));
        Console.WriteLine();
        CRUD.UpdateCategory((from i in CRUD.GetCategories() where i.Name == "Bike" select i.Id).First(),new Category { Name = "NewBike"});
        CRUD.GetProducts((from i in CRUD.GetCategories() where i.Name == "NewBike" select i.Id).First())?.ForEach(p => Console.WriteLine("Name: {0}  Category: {1}", p.Name, p.Category.Name));
        Console.WriteLine();
        CRUD.DeleteCategory((from i in CRUD.GetCategories() where i.Name == "NewBike" select i.Id).First());
        CRUD.GetProducts().ForEach(p => Console.WriteLine("Name: {0}  Category: {1}", p.Name, p.Category.Name));
    }
}
