using TheBigStore.Repository.Domain;
using TheBigStore.UnitTesting.UnitTestConfig;

namespace TheBigStore.UnitTesting.Tests
{
    public class UnitTestDeleteCustomer
    {

        [Fact]
        public void TestDeleteCustomer()
        {
            // Arrange
            UnitTheBigStoreContext.RecreateDatabase();
            TheBigStoreContext context = UnitTheBigStoreContext.Create();

        }
    }
}
