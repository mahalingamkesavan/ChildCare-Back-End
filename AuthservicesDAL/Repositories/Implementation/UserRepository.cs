using AuthservicesDAL.DataContext;
using AuthservicesDAL.Repositories.IRepositories;
using AuthServicesUtility;
using businessServicess.models.RequestModels.auth;
using Microsoft.AspNetCore.Identity;

namespace AuthservicesDAL.Repositories.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager; private readonly RoleManager<IdentityRole> _roleManager;
        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
        }
        public async Task<ApplicationUser> FindByNameAsync(string name)
        {
            var data = await _userManager.FindByNameAsync(name);

            return data;
        }
        public async Task<ApplicationUser> FindByEmailAsync(string email)
        {
            var Checkemail = await _userManager.FindByEmailAsync(email);

            return Checkemail;
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            var isTrue = await _userManager.CheckPasswordAsync(user, password);
            if (isTrue) return true;
            return false;
        }
        public async Task<IList<string>> GetRolesAsync(ApplicationUser model)
        {
            return await _userManager.GetRolesAsync(model);
        }
        public async Task<string> RegisterUser(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Username);

            if (userExists != null) return ConstantVariables.Exist;

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return ConstantVariables.Ckeck;

            if (await _roleManager.RoleExistsAsync(UserRoles.Parent))
                await _userManager.AddToRoleAsync(user, UserRoles.Parent);

            return ConstantVariables.Created;
        }
        public async Task<string> Register(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Username);

            if (userExists != null) return ConstantVariables.Exist;

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return ConstantVariables.Ckeck;

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
                await _userManager.AddToRoleAsync(user, UserRoles.User);

            return ConstantVariables.Created;
        }
        public async Task<string> RegisterAdmin(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null) return ConstantVariables.Exist;

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded) return ConstantVariables.Ckeck;

            if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
                await _userManager.AddToRoleAsync(user, UserRoles.Admin);
            return ConstantVariables.Created;
        }
        public async Task<string> GeneratePasswordResetToken(ApplicationUser identityUser)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);

            return token;
        }
        public async Task<IdentityResult> ResertPassword(ResertPasswortwithOtp changePassword)
        {

            var data = changePassword.applicationCantext;

            var result = await _userManager.ResetPasswordAsync((ApplicationUser)data, changePassword.UserName, changePassword.NewPassword);

            return result;
        }
        public Task<string> Sendvalue(ResetPasswordSaveOtpModule saveTokenModule)
        {
            throw new NotImplementedException();
        }
    }
}

