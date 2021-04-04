using Services.Users.Models;

namespace Services.Users.Contracts
{
    public interface IAuthService : IBaseDataService
    {
        AuthModel GetAuthData(string id);
        bool isEmailUniq(string email);
        bool IsUsernameUniq(string username);
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
    }
}
