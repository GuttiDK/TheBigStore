using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Extensions;
using TheBigStore.Repository.Extensions.Paging;
using TheBigStore.Repository.Interfaces.OrderInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.OrderRepositories
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public ItemRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Item>> SearchProductByWord(string word)
        {
            return await _dbContext.Products.AsNoTracking().Where(x => x.ItemName.Contains(word)).ToListAsync();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        // Method to handle adding product to cart with a user if user has not a customerid yet then it will create a new customer
        // if the user has a customerid then it will check if the product is already in the cart
        // and if the product is already in the cart, it will increase the quantity
        // and if the product is not in the cart, it will add the product to the cart
        // user will also input a new address for the order
        public async Task AddToCart(int productId, int userId, Customer customer, Address address)
        {
            var product = await _dbContext.Products.FindAsync(productId);
            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            var customerInput = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == userId);

            if (customerInput == null)
            {
                var addressNew = new Address
                {
                    City = address.City,
                    Country = address.Country,
                    StreetName = address.StreetName,
                    StreetNumber = address.StreetNumber,
                    ZipCode = address.ZipCode
                };
                await _dbContext.Addresses.AddAsync(addressNew);
                var addressNew2 = await _dbContext.Addresses.LastAsync();
                address.Id = addressNew2.Id;

                customerInput = new Customer
                {
                    Id = userId,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    AddressId = address.Id
                };
                await _dbContext.Customers.AddAsync(customerInput);
            }

            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.CustomerId == customerInput.Id );

            if (order == null)
            {
                order = new Order
                {
                    CustomerId = customerInput.Id,
                    DeliveryDate = DateTime.Now.AddDays(7),
                    OrderDate = DateTime.Now,
                    Status = Enums.OrderStatusEnum.Pending,
                };
                await _dbContext.Orders.AddAsync(order);
            }

            var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderId == order.Id && x.ItemId == productId);

            if (orderItem == null)
            {
                orderItem = new ItemOrder
                {
                    OrderId = order.Id,
                    ItemId = productId,
                    Status = Enums.OrderStatusEnum.Pending,
                    Quantity = 1,
                };
                await _dbContext.OrderItems.AddAsync(orderItem);
            }
            else
            {
                orderItem.Quantity++;
            }

            await _dbContext.SaveChangesAsync();
            return;
        }

    }
}
