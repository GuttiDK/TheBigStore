using TheBigStore.Repository.Interfaces.UserInterfaces;
using TheBigStore.Repository.Models;
using TheBigStore.Service.DataTransferObjects;
using TheBigStore.Service.Interfaces.UserInterfaces;
using TheBigStore.Service.Services.GenericServices;
using TheBigStore.Service.Services.MappingServices;

namespace TheBigStore.Service.Services.UserServices
{
    public class RoleService(MappingService mappingService, IRoleRepository roleRepository) : GenericService<RoleDto, IRoleRepository, Role>(mappingService, roleRepository), IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly MappingService _mappingService = mappingService;
    }
}
