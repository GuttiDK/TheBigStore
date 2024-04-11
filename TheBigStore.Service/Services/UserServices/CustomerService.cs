using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.UserServices
{
    public class CustomerService(MappingService mappingService, ICustomerRepository customerRepository) : GenericService<CustomerDto, ICustomerRepository, Customer>(mappingService, customerRepository), ICustomerService
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;
        private readonly MappingService _mappingService = mappingService;
    }
}
