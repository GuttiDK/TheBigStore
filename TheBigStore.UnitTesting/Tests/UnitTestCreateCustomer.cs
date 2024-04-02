using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;
using TheBigStore.UnitTesting.UnitTestConfig;

namespace TheBigStore.UnitTesting.Tests
{
    public class UnitTestCreateCustomer
    {

        [Fact]
        public void TestCreateCustomer()
        {
            // Arrange
            UnitTheBigStoreContext.RecreateDatabase();
            TheBigStoreContext context = UnitTheBigStoreContext.Create();

            // Act
            context.Customers.Add(new Customer { FirstName = "Mikkel", LastName = "Cronberg", Email = "" });

            //Customer customer = new() { FirstName = "Mikkel", LastName = "Cronberg", Email = "" };
            //ICarService service = new CarService(context);

            // Act
            
            //var context = service.CreateCar(CarToCreate);

            //Assert.NotEqual(default, context.CarIdentifer);
            //Assert.Equal(CarToCreate.Name, context.Name);
            //Assert.Equal(CarToCreate.Consumption, context.Consumption);
            //Assert.Equal(CarToCreate.ManufacturerId, context.ManufacturerId);

        }
    }
}
