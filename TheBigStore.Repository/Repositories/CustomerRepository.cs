using Microsoft.EntityFrameworkCore;
using TheBigStore.Repository.Domain;
using TheBigStore.Repository.Interfaces;
using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Repositories
{
    public class CustomerRepository(TheBigStoreContext dbContext) : GenericRepository<Customer>(dbContext), ICustomerRepository
    {
    }
}
