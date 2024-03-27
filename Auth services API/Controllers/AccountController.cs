using AuthServicesBAL.IServices;
using AuthServicesUtility;
using businessServicess.models.RequestModels.auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthServicesAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        // DI
        public AccountController(IUserService iuserservice) { _userService = iuserservice; }
        ///<summary>User Login 
        /// HttpPost method, use to valid user Get the Token and User Some Info
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login([FromBody] LoginModel model)
        {
            var response = await _userService.Login(model);
            if (response.token != null)
            {
                return Ok(response);
            }
            return Unauthorized(new Response { Status = ConstantVariables.Fail, message = ConstantVariables.InvalidUser });
        }
        ///<summary> Register new User  
        /// HttpPost method, use to Regist the new user and get the Responce Message 
        /// <param name="model"></param>
        /// <returns></returns>
        ///<summary> Register new User  
        /// HttpPost method, use to Regist the new user and get the Responce Message 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
        {
            var isSuccess = await _userService.RegisterUser(model);
            if (isSuccess.ToString() == ConstantVariables.Exist)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.User_Already_Exists });
            if (isSuccess.ToString() == ConstantVariables.Ckeck)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.CreationFail });
            }
            return Ok(new Response { Status = ConstantVariables.Success, message = ConstantVariables.CreateSuccessFull });
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("Register-Employee")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var isSuccess = await _userService.Register(model);
            if (isSuccess.ToString() == ConstantVariables.Exist)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.User_Already_Exists });
            if (isSuccess.ToString() == ConstantVariables.Ckeck)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.CreationFail });
            }
            return Ok(new Response { Status = ConstantVariables.Success, message = ConstantVariables.CreateSuccessFull });
        }
        ///<summary> Register new Admin  
        /// HttpPost method, use to Regist the new Admin and get the Responce Message 
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var isSuccess = await _userService.RegisterUser(model);
            if (isSuccess.ToString() == ConstantVariables.Exist)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.User_Already_Exists });
            if (isSuccess.ToString() == ConstantVariables.Ckeck)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.CreationFail });
            return Ok(new Response { Status = ConstantVariables.Success, message = ConstantVariables.CreateSuccessFull });
        }
        [HttpGet]
        [Route("GetUserProfile")]
        [Authorize]
        public async Task<IActionResult> Getuserprofile()
        {
            return Ok(await _userService.GetUserprofile(User.Claims));
        }
        [HttpPut]
        [Route("ResertPassword")]
        [Authorize(Roles = "Admin,Customer,User")]
        public async Task<IActionResult> ResetPassword([FromBody] ChangePassword changePassword)
        {
            var isSuccess = await _userService.ResetPassword(changePassword);

            if (isSuccess.ToString() == ConstantVariables.UsernotFound)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.UsernotFound });

            if (isSuccess.ToString() == ConstantVariables.Ckeck)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = ConstantVariables.Error, message = ConstantVariables.PasswordRules });

            if (isSuccess.ToString() == ConstantVariables.IncorrectPassword)
                return StatusCode(StatusCodes.Status401Unauthorized, new Response { Status = ConstantVariables.Error, message = ConstantVariables.IncorrectPassword });

            return Ok(new Response { Status = ConstantVariables.Success, message = ConstantVariables.PasswordChangeSuccess });
        }
    }
}
