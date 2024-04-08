using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class AddressRepository(TheBigStoreContext dbContext) : GenericRepository<Address>(dbContext), IAddressRepository
    {
    }
}
