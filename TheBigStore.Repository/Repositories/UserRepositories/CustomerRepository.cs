using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly TheBigStoreContext _dbContext;
        public CustomerRepository(TheBigStoreContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        new public async Task<Customer> GetByIdAsync(int id)
        {
            Customer entity = await _dbContext.Customers.AsNoTracking().Include(c => c.Address).SingleOrDefaultAsync(c => c.Id == id);
            return entity;
        }

        // Method to handle adding product to cart with a user if user has not a customerid yet then it will create a new customer
        // if the user has a customerid then it will check if the product is already in the cart
        // and if the product is already in the cart, it will increase the quantity
        // and if the product is not in the cart, it will add the product to the cart
        // user will also input a new address for the order
        public async Task AddToCart(List<Item> items, int userId, Customer customer, Address address)
        {
            // Add the address to the database
            await _dbContext.Addresses.AddAsync(address);
            // Find the lastest address added to the database
            var latestAddress = await _dbContext.Addresses.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (latestAddress == null)
            {
                throw new Exception("Address not found.");
            }

            // Check if the customer already exists
            var existingCustomer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.Id == userId);

            if (existingCustomer == null)
            {
                // If the customer doesn't exist, create a new customer
                var newCustomer = new Customer
                {
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    AddressId = latestAddress.Id // Assign the provided address directly
                };

                await _dbContext.Customers.AddAsync(newCustomer);
            }

            // Check if there's an existing order for the customer
            var order = await _dbContext.Orders.FirstOrDefaultAsync(x => x.CustomerId == userId && x.Status == Enums.OrderStatusEnum.Pending);

            if (order == null)
            {
                // If no order exists, create a new order
                order = new Order
                {
                    CustomerId = userId,
                    DeliveryDate = DateTime.Now.AddDays(7),
                    OrderDate = DateTime.Now,
                    Status = Enums.OrderStatusEnum.Pending,
                };

                await _dbContext.Orders.AddAsync(order);
            }

            // Add items to the order
            foreach (var item in items)
            {
                // Check if the item exists
                var existingItem = await _dbContext.Products.FindAsync(item.Id);
                if (existingItem == null)
                {
                    throw new Exception($"Item with ID {item.Id} not found.");
                }

                await AddItemToOrder(existingItem, order);
            }

            // Save changes after all modifications
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddItemToOrder(Item item, Order order)
        {
            // Check if the item order already exists
            var orderItem = await _dbContext.OrderItems.FirstOrDefaultAsync(x => x.OrderId == order.Id && x.ItemId == item.Id);

            if (orderItem == null)
            {
                // If the item order doesn't exist, create a new one
                orderItem = new ItemOrder
                {
                    OrderId = order.Id,
                    ItemId = item.Id,
                    Status = Enums.OrderStatusEnum.Pending,
                    Quantity = item.Quantity,
                };
                await _dbContext.OrderItems.AddAsync(orderItem);
            }
            else
            {
                // If the item order exists, increment quantity
                orderItem.Quantity++;
            }
        }

    }
}

