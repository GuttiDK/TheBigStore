namespace TheBigStore.Service.DataTransferObjects
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public bool IsAdmin { get; set; } = false;
        public List<UserDto> Users { get; set; } = [];
    }
}
