using TheBigStore.Repository.Domain;
using TheBigStore.UnitTesting.UnitTestConfig;

namespace TheBigStore.UnitTesting.Tests
{
    public class UnitTestFindCustomer
    {
        [Fact]
        public void TestFindCustomer()
        {
            // Arrange
            UnitTheBigStoreContext.RecreateDatabase();
            TheBigStoreContext context = UnitTheBigStoreContext.Create();

        }
    }
}
