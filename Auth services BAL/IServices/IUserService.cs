using AuthservicesDAL.DataContext;
using businessServicess.models.RequestModels.auth;
using System.Security.Claims;

namespace AuthServicesBAL.IServices
{
    public interface IUserService
    {
        Task<LoginResponse> Login(LoginModel model);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<string> Register(RegisterModel model);
        Task<string> RegisterUser(RegisterModel model);
        Task<string> RegisterAdmin(RegisterModel model);
        Task<UserprofileDTO> GetUserprofile(IEnumerable<Claim> Data);
        Task<string> ResetPassword(ChangePassword changePassword);
        Task<string> ResetPasswordUser(string email);
        Task<string> ResetPasswordCheakOtp(ChangePasswordOpt passwordOpt);
    }
}
