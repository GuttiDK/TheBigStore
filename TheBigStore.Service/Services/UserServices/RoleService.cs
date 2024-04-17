using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.UserServices
{
    public class RoleService : GenericService<RoleDto, IRoleRepository, Role>, IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly MappingService _mappingService;

        public RoleService(IRoleRepository roleRepository, MappingService mappingService) : base(mappingService, roleRepository)
        {
            _roleRepository = roleRepository;
            _mappingService = mappingService;
        }
    }
}
