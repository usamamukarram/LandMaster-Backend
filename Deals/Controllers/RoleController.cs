using Deals.Dto.Role;
using Deals.Dto.User;
using Deals.Interface;
using Deals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Deals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly IRole _role;

        public RoleController(IRole role)
        {
            _role = role;
        }

        [HttpGet("AllRoles")]
        public async Task<ActionResult<ServiceResponse<RoleDto>>> GetAllRoleList()
        {

            var Roles = await _role.GetAllRoles();
            return Ok(Roles);

        }
        [HttpGet("getRoleById/{roleId}")]
        public async Task<ActionResult<ServiceResponse<RoleDto>>> GetRoleById( int roleId)
        {

            var Role = await _role.GetRoleById(roleId);
            return Ok(Role);

        }
    }
}
