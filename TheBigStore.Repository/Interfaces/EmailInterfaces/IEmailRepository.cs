using TheBigStore.Repository.Models;

namespace TheBigStore.Repository.Interfaces.EmailInterfaces
{
    public interface IEmailRepository
    {
        Task SendPasswordResetAsync(User user);
    }
}
