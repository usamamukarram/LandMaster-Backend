using Deals.Dto.Landlord;
using Deals.Dto.Tenant;
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
    public class TenantController : ControllerBase
    {
        private readonly ITenant _tenant;

        public TenantController(ITenant tenant)
        {
             _tenant = tenant;
        }

        [HttpPost("AddTenant")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> AddTenant(AddTenantDto AddTenantRequest)
        {

            var response = await _tenant.AddTenant(AddTenantRequest);



            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("AllTenant")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> GetAllLandlordList()
        {

            var tenant = await _tenant.GetAllTenants();
            return Ok(tenant);

        }
        [HttpGet("TenantById/{TenantId}")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> GetLandlordByID(int TenantId)
        {
            var tenant = await _tenant.GetTenantByID(TenantId);
            return Ok(tenant);
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> UpdateStatus([FromQuery] int TenantId, [FromQuery] bool status)
        {
            var tenant = await _tenant.UpdateTenantStatus(TenantId, status);
            return Ok(tenant);
        }
        [HttpPut("UpdateTenant")]
        public async Task<ActionResult<ServiceResponse<Tenant>>> UpdateLandlord(UpdateTenantDto UpdateTenantDtoRequest)
        {
            var tenant = await _tenant.UpdateTenant(UpdateTenantDtoRequest);
            return Ok(tenant);
        }
    }
}
