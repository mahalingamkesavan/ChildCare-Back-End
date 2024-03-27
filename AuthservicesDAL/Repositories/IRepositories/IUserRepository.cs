using AuthservicesDAL.DataContext;
using businessServicess.models.RequestModels.auth;
using Microsoft.AspNetCore.Identity;

namespace AuthservicesDAL.Repositories.IRepositories
{
    public interface IUserRepository
    {
        Task<ApplicationUser> FindByNameAsync(string name);
        Task<ApplicationUser> FindByEmailAsync(string email);
        Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
        Task<string> Register(RegisterModel model);
        Task<string> RegisterUser(RegisterModel model);
        Task<string> RegisterAdmin(RegisterModel model);
        Task<IList<string>> GetRolesAsync(ApplicationUser model);
        Task<string> GeneratePasswordResetToken(ApplicationUser obj);
        Task<IdentityResult> ResertPassword(ResertPasswortwithOtp changePassword);
        Task<string> Sendvalue(ResetPasswordSaveOtpModule saveTokenModule);
    }
}
