using TheBigStore.Repository.Domain;
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

        }
    }
}
