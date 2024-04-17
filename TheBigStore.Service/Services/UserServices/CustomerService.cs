using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.UserServices
{
    public class CustomerService : GenericService<CustomerDto, ICustomerRepository, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly MappingService _mappingService;

        public CustomerService(MappingService mappingService, ICustomerRepository customerRepository) : base(mappingService, customerRepository)
        {
            _customerRepository = customerRepository;
            _mappingService = mappingService;
        }

        public async Task AddToCart(List<ItemDto> items, int userId, CustomerDto customer, AddressDto address)
        {
            await _customerRepository.AddToCart(_mappingService._mapper.Map<List<Item>>(items), userId, _mappingService._mapper.Map<Customer>(customer), _mappingService._mapper.Map<Address>(address));
        }
    }
}
