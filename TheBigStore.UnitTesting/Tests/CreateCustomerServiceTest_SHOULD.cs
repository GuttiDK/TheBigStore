using TheBigStore.Repository.Models;
using TheBigStore.Service.Services;
using TheBigStore.Repository.Repositories;
using TheBigStore.Repository.Domain;

namespace TheBigStore.UnitTesting.Tests
{
    public class CreateCustomerServiceTest_SHOULD
    {
        private static readonly MappingService _mappingService = new();

        [Fact]
        public void CreateWhenEntityIsNotNull()
        {
            // Arrange
            TheBigStoreContext context = new();
            var sut = new CustomerService(_mappingService, new CustomerRepository(context));


            // Arrange
            var command = new CustomerDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                Phone = "1234567890",
                Address = new AddressDto
                {
                    City = "New York",
                    Country = "USA",
                    StreetName = "Broadway",
                    StreetNumber = "123",
                    ZipCode = "10001"
                }
            };

            // Act
            var result = sut.CreateAsync(command);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateWhenEntityIsDifferent()
        {
            // Arrange
            TheBigStoreContext context = new();
            var sut = new CustomerService(_mappingService, new CustomerRepository(context));

            // Arrange
            var command = new CustomerDto
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@example.com",
                Phone = "1234567890",
                Address = new AddressDto
                {
                    City = "New York",
                    Country = "USA",
                    StreetName = "Broadway",
                    StreetNumber = "123",
                    ZipCode = "10001"
                }
            };

            var differentCommand = new CustomerDto
            {
                FirstName = command.FirstName + " different",
                LastName = command.LastName + " different",
                Email = command.Email + " different",
                Phone = command.Phone + " different",
                Address = new AddressDto
                {
                    City = "different",
                    Country = "different",
                    StreetName = "different",
                    StreetNumber = "different",
                    ZipCode = "different",
                }
            };

            // Act
            var result = sut.CreateAsync(differentCommand);

            // Assert
            Assert.NotNull(result);
        }
    }
}
