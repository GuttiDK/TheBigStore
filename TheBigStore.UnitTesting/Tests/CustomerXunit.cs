using TheBigStore.Repository.Repositories.UserRepositories;
using TheBigStore.Service.Services.UserServices;

namespace TheBigStore.UnitTesting.Tests
{
    public class CustomerXunit
    {
        [Fact]
        public async Task TestCreateCustomerAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new CustomerService(new MappingService(), new CustomerRepository(_context));

            //Arrange

            CustomerDto customerDTO = new CustomerDto { FirstName = "John", LastName = "Doe", Phone = "12436587" };

            //Act

            await _service.CreateAsync(customerDTO);

            //Assert
            var actualCustomer = _context.Customers.ToList().Last();

            Assert.Equal(customerDTO.FirstName, actualCustomer.FirstName);
            Assert.Equal(customerDTO.LastName, actualCustomer.LastName);
        }

        [Fact]
        public async Task TestGetAllCustomersAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new CustomerService(new MappingService(), new CustomerRepository(_context));

            //Arrange

            CustomerDto customerDTO = new CustomerDto { FirstName = "John", LastName = "Doe", Phone = "12436587" };

            await _service.CreateAsync(customerDTO);

            //Act

            var customers = await _service.GetAllAsync();

            //Assert
            Assert.NotEmpty(customers);
        }

        [Fact]
        public async Task TestGetCustomerByIdAsync()
        {
            var _context = ContextCreater.CreateContext();
            var _service = new CustomerService(new MappingService(), new CustomerRepository(_context));

            //Arrange

            CustomerDto customerDTO = new CustomerDto { FirstName = "John", LastName = "Doe", Phone = "12436587" };

            await _service.CreateAsync(customerDTO);

            //Act

            var customer = await _service.GetByIdAsync(1);

            //Assert
            Assert.NotNull(customer);
        }

    }
}
