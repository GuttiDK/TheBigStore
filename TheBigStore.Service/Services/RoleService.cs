using TheBigStore.Repository;
using TheBigStore.Repository.Models;
using TheBigStore.Service.Interfaces;

namespace TheBigStore.Service.Services
{
    public class RoleService(MappingService mappingService, IRoleRepository roleRepository) : GenericService<RoleDto, IRoleRepository, Role>(mappingService, roleRepository), IRoleService
    {
        private readonly IRoleRepository _roleRepository = roleRepository;
        private readonly MappingService _mappingService = mappingService;
    }
}
