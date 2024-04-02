using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository
{
    public class Program
    {
        public static void Main()
        {
            TheBigStoreContext context = new();

            // Oprette noget data og gemme det i databasen for mig

            // Opretter en ny rolle
            context.Roles.Add(new Role { RoleName = "SuperUser" });
            context.Roles.Add(new Role { RoleName = "Admin" });
            context.Roles.Add(new Role { RoleName = "User" });

            // Opretter en ny adresse
            context.Addresses.Add(new Address { StreetName = "Hovedgaden", StreetNumber = "1", ZipCode = "1234", City = "København", Country = "Danmark" });
            context.Addresses.Add(new Address { StreetName = "Hovedgaden", StreetNumber = "2", ZipCode = "1234", City = "København", Country = "Danmark" });
            context.Addresses.Add(new Address { StreetName = "Hovedgaden", StreetNumber = "3", ZipCode = "1234", City = "København", Country = "Danmark" });

            // Opretter en ny kategori
            context.Category.Add(new Category { CategoryName = "Elektronik" });
            context.Category.Add(new Category { CategoryName = "Bøger" });
            context.Category.Add(new Category { CategoryName = "Tøj" });
            context.Category.Add(new Category { CategoryName = "Mad" });

            // Opretter en ny vare
            context.Products.Add(new Item { ItemName = "Computer", Price = 10000, Stock = 10, CategoryId = 1 });
            context.Products.Add(new Item { ItemName = "Bog", Price = 200, Stock = 100, CategoryId = 2 });
            context.Products.Add(new Item { ItemName = "T-shirt", Price = 100, Stock = 50, CategoryId = 3 });
            context.Products.Add(new Item { ItemName = "Pizza", Price = 50, Stock = 4, CategoryId = 4 });

            // Opretter en ny bruger
            context.Users.Add(new User { UserName = "Mikkel", Password = "Cronberg", Email = "mikkel@cronberg.com", RoleId = 1, CustomerId = 1 });
            context.Users.Add(new User { UserName = "Admin", Password = "Admin", Email = "admin@admin.com", RoleId = 2 });
            context.Users.Add(new User { UserName = "User", Password = "User", Email = "user@user.com", RoleId = 3 });
            context.Users.Add(new User { UserName = "User2", Password = "User2", Email = "", RoleId = 3 });

            // Opretter en ny kunde
            context.Customers.Add(new Customer { FirstName = "Mikkel", LastName = "Cronberg", Email = "mikkel@cronberg.com", Phone = "12345678", AddressId = 1 });
            context.Customers.Add(new Customer { FirstName = "Admin", LastName = "Admin", Email = "admin@admin.com", Phone = "213213124", AddressId = 2 });
            context.Customers.Add(new Customer { FirstName = "User", LastName = "User", Email = "user@user.com", Phone = "32432432", AddressId = 3 });
            context.Customers.Add(new Customer { FirstName = "User2", LastName = "User2", Email = "user2@gmail.com", Phone = "31423434", AddressId = 3 });

            // Gemmer dataen i databasen
            context.SaveChanges();
        }
    }
}
