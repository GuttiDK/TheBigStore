using TheBigStore.Repository.Domain;
using TheBigStore.UnitTesting.UnitTestConfig;

namespace TheBigStore.UnitTesting.Tests
{
    public class UnitTestCustomerCount
    {
        [Fact]
        public void TestCustomerCount()
        {
            // Arrange
            UnitTheBigStoreContext.RecreateDatabase();
            TheBigStoreContext context = UnitTheBigStoreContext.Create();
        }
    }
}
