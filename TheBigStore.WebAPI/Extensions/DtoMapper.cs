using TheBigStore.Service.DataTransferObjects;
using TheBigStore.WebAPI.Models;

namespace TheBigStore.WebAPI.Extensions
{
    public static class DtoMapper
    {
        public static CategoryDto MapCategoryToDto(this CategoryModel category)
        {
            return new CategoryDto
            {
                CategoryName = category.CategoryName
            };
        }

        public static ItemDto MapItemToDto(this ItemModel item)
        {
            return new ItemDto
            {
                ItemName = item.ItemName,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId,
                ImageId = item.ImageId,
                Stock = item.Stock,
                Quantity = item.Quantity,
            };
        }

        public static List<ItemOrderDto> MapItemOrderToDto(this List<ItemOrderModel> itemOrder)
        {
            List<ItemOrderDto> itemOrderDTOs = new();

            foreach (var item in itemOrder)
            {
                itemOrderDTOs.Add(new ItemOrderDto
                {
                    ItemId = item.ItemId,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity,
                    Status = item.Status,
                });
            }

            return itemOrderDTOs;
        }

        public static OrderDto MapOrderToDto(this OrderModel order)
        {
            return new OrderDto
            {
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerId = order.CustomerId
            };
        }

        public static RoleDto MapRoleToDto(this RoleModel role)
        {
            return new RoleDto
            {
                RoleName = role.RoleName
            };
        }

        public static UserDto MapUserToDto(this UserModel user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = user.RoleId,
            };
        }

        public static AddressDto MapAddressToDto(this AddressModel address)
        {
            return new AddressDto
            {
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                ZipCode = address.ZipCode
            };
        }

        public static ImageDto MapItemImageToDto(this ImageModel itemImage)
        {
            return new ImageDto
            {
                ImageUrl = itemImage.ImageUrl,
                DateCreated = itemImage.DateCreated,
            };

        }

    }
}
