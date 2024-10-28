using eHnue.Shared;

namespace eHnue.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
        
    }
}
