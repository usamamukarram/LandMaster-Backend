using Deals.Data;
using Deals.Dto.User;
using Deals.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController( IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(RegisterDro RegistertRequest)
        {

            var response = await _authRepository.Register(
                new User { 
                    UserName = RegistertRequest.Username, 
                    Email=RegistertRequest.Email,
                    PhoneNumber=RegistertRequest.PhoneNumber ,
                    FirstName=RegistertRequest.FirstName,
                    LastName=RegistertRequest.LastName,
                    Notes=RegistertRequest.Notes
                }
                , RegistertRequest.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]

        public async Task<ActionResult<ServiceResponse<int>>> Login(LoginDto request)
        {
            var response = await _authRepository.Login(request.Username, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
