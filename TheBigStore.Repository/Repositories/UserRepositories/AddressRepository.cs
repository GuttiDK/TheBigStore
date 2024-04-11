using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Repository.Repositories.GenericRepositories;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class AddressRepository(TheBigStoreContext dbContext) : GenericRepository<Address>(dbContext), IAddressRepository
    {
    }
}
