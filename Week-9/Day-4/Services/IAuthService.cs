using AuthService.Models;

namespace AuthService.Services
{
    public interface IAuthService
    {
        Task<User> Register(User user);
        Task<string> Login(string email, string password);
    }
}