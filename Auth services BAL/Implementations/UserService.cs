using AuthServicesBAL.IServices;
using AuthservicesDAL.DataContext;
using AuthservicesDAL.Repositories.IRepositories;
using AuthServicesUtility;
using businessServicess.models.RequestModels.auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

#nullable disable

namespace AuthServicesBAL.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _IUserRepository; private readonly IConfiguration _configuration;
        public UserService(IUserRepository iUserRepository, IConfiguration configuration)
        {
            _IUserRepository = iUserRepository;
            _configuration = configuration;
        }
        public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
        {
            return await _IUserRepository.CheckPasswordAsync(user, password);
        }
        public async Task<string> RegisterUser(RegisterModel model)
        {
            return await _IUserRepository.RegisterUser(model);
        }
        public async Task<string> Register(RegisterModel model)
        {
            return await _IUserRepository.Register(model);
        }
        public async Task<string> RegisterAdmin(RegisterModel model)
        {
            return await _IUserRepository.RegisterAdmin(model);
        }
        public async Task<UserprofileDTO> GetUserprofile(IEnumerable<Claim> Data)
        {
            var Username = Data.Cast<Claim>().Where(x => x.Type == ClaimTypes.Name).FirstOrDefault().Value;
            var UserEmail = Data.Cast<Claim>().Where(x => x.Type == ClaimTypes.Email).FirstOrDefault().Value;
            var UserRole = Data.Cast<Claim>().Where(x => x.Type == ClaimTypes.Role).FirstOrDefault().Value;

            var data = Task.FromResult(new UserprofileDTO() { Username = Username, Email = UserEmail, Role = UserRole });

            return await data;
        }
        public async Task<LoginResponse> Login(LoginModel model)
        {
            LoginResponse response = new LoginResponse();

            var user = await _IUserRepository.FindByNameAsync(model.Username);

            if (user != null && await _IUserRepository.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await _IUserRepository.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim (ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                response = new LoginResponse()
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    roles = userRoles.ToList(),
                    Username = user.UserName,

                };
                return response;
            }
            return response;
        }
        public async Task<string> ResetPassword(ChangePassword changePassword)
        {

            ResertPasswortwithOtp passwortwithToken = new ResertPasswortwithOtp();

            var applicationUser = await _IUserRepository.FindByNameAsync(changePassword.UserName);

            if (applicationUser == null) return ConstantVariables.UsernotFound;

            if (await _IUserRepository.CheckPasswordAsync(applicationUser, changePassword.OldPassword))
            {

                var token = await _IUserRepository.GeneratePasswordResetToken(applicationUser);

                passwortwithToken.applicationCantext = applicationUser;

                passwortwithToken.UserName = token;

                passwortwithToken.NewPassword = changePassword.NewPassword;

                var result = await _IUserRepository.ResertPassword(passwortwithToken);

                if (!result.Succeeded) return ConstantVariables.Ckeck;

                return result.ToString();
            }
            else return ConstantVariables.IncorrectPassword;
        }
        public async Task<string> ResetPasswordUser(string email)
        {
            ResetPasswordSaveOtpModule obj = new ResetPasswordSaveOtpModule();

            var FindEmail = await _IUserRepository.FindByEmailAsync(email);

            Random rnd = new Random();

            int rendomnumber = rnd.Next();

            if (FindEmail == null) { return ConstantVariables.Check; }
            else
            {
                obj.RandomNumber = rendomnumber; obj.UserId = FindEmail.Id;

                var result = await _IUserRepository.Sendvalue(obj);

                //MailSender.SendMail(rendomnumber, FindEmail.Email);

                return ConstantVariables.Success;
            }
        }
        public Task<string> ResetPasswordCheakOtp(ChangePasswordOpt passwordOpt)
        {
            // First check the otp number
            // then call the ResetPassword bal method 
            throw new NotImplementedException();
        }
    }
}
