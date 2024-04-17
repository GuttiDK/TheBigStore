using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Repository.Repositories.UserRepositories
{
    public class AddressService : GenericService<AddressDto, IAddressRepository, Address>, IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly MappingService _mappingService;

        public AddressService(MappingService mappingService, IAddressRepository addressRepository) : base(mappingService, addressRepository)
        {
            _addressRepository = addressRepository;
            _mappingService = mappingService;
        }
    }
}
