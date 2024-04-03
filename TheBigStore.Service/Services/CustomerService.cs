using TheBigStore.Repository.Interfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Service.Services
{
    public class CustomerService(MappingService mappingService, ICustomerRepository customerRepository) : GenericService<CustomerDto, ICustomerRepository, Customer>(mappingService, customerRepository), ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly MappingService _mappingService = mappingService;
    }
}
