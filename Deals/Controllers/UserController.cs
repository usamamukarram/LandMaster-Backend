using Azure;
using Deals.Data;
using Deals.Dto.User;
using Deals.Interface;
using Deals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace Deals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly IAuthRepository _authRepository;

        public UserController( IUser user, IAuthRepository authRepository)
        {
            _user = user;
            _authRepository = authRepository;
        }
        //[Authorize(Roles = "2")]
        [Authorize]
        [HttpGet("AllUsers")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetAllUsersList()
        {


            var Users = await _user.GetAllUsers();
            return Ok(Users);

        }
        [HttpGet("AllVerifiedUsers")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetAllVerifiedUsersList()
        {
            
            var Users = await _user.ListOfAllVerifiedUsers();
            return Ok(Users);

        }
        //[Authorize(Roles = "1")]
        [Authorize]
        [HttpGet("UserById/{userId}")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> GetUser(int userId)
        {
            var User = await _user.GetUserById( userId);
            return Ok(User);
        }
        [Authorize]
        [HttpPost("UpdateVerifyStatus")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UpdateStatus([FromQuery] int userId, [FromQuery] bool status)
        {
            var User = await _user.UpdateUserVerifierStatus(userId, status);
            return Ok(User);
        }
        [HttpPost("ForgotChangePassword")]
      
        public async Task<ActionResult<ServiceResponse<UserDto>>> forgotChangePassword(LoginDto RegistertRequest)
        {

            var response = await _authRepository.ForgotChangePassword(
                new User
                {
                    UserName = RegistertRequest.Username,
                   
                }
                , RegistertRequest.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpPost("ChangePassword")]

        public async Task<ActionResult<ServiceResponse<UserDto>>> ChangePassword(ChangePasswordDto changePasswordtRequest)
        {

            var response = await _authRepository.ChangePassword(
                new User
                {
                    UserId = changePasswordtRequest.Id,

                }
                , changePasswordtRequest.OldPassword,changePasswordtRequest.NewPassword);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [Authorize]
        [HttpPut("DeleteUser")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> SoftDeleteUser([FromQuery] int userId)
        {
            var User = await _user.deleteUser(userId);
            return Ok(User);
        }
        [Authorize]
        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UpdateUser(UpdateUserDto userRequest)
        {
            var User = await _user.UpdateUser(userRequest);
            return Ok(User);
        }
        [Authorize]
        [HttpPut("UpdateUserRole")]
        public async Task<ActionResult<ServiceResponse<UserDto>>> UpdateUserRole( int userId, int userRole)
        {
            var User = await _user.UpateRoleOfUser(userId, userRole);
            return Ok(User);
        }
    }
}
