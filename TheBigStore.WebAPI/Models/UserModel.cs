namespace TheBigStore.WebAPI.Models
{
    public class UserModel
    {
        // User
        public string UserName { get; set; }
        public string Password { get; set; } 
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }
}
