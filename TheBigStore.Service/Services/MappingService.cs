using AutoMapper;
using TheBigStore.Repository.Models;

namespace TheBigStore.Service.Services
{
    public class MappingService
    {
        public readonly IMapper _mapper;

        public MappingService() 
        {
            MapperConfiguration config = new(cfg =>
            {
                cfg.CreateMap<Role, RoleDto>();
                cfg.CreateMap<RoleDto, Role>();

                cfg.CreateMap<Item, ItemDto>();
                cfg.CreateMap<ItemDto, Item>();

                cfg.CreateMap<ItemOrder, ItemOrderDto>();
                cfg.CreateMap<ItemOrderDto, ItemOrder>();

                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();

                cfg.CreateMap<Address, AddressDto>();
                cfg.CreateMap<AddressDto, Address>();

                cfg.CreateMap<Order, OrderDto>();
                cfg.CreateMap<OrderDto, Order>();

                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();

                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<CategoryDto, Category>();
            });

            try
            {
                _mapper = config.CreateMapper();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to create map: " + ex.Message);
            }
        }
    }
}
