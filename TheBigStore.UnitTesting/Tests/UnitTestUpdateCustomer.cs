using TheBigStore.Repository.Domain;
using TheBigStore.UnitTesting.UnitTestConfig;

namespace TheBigStore.UnitTesting.Tests
{
    public class UnitTestUpdateCustomer
    {
        [Fact]
        public void TestUpdateCustomer()
        {
            // Arrange
            UnitTheBigStoreContext.RecreateDatabase();
            TheBigStoreContext context = UnitTheBigStoreContext.Create();

        }
    }
}
