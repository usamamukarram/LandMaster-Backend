using Deals.Dto.Buyyer;
using Deals.Dto.Landlord;
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
    public class LandlordController : ControllerBase
    {
        private readonly Ilandlord _landlord;

        public LandlordController(Ilandlord ilandlord)
        {
            _landlord = ilandlord;
        }

        [HttpPost("AddLandlord")]
        public async Task<ActionResult<ServiceResponse<Landlord>>> AddLandlord(AddLandlordDto AddLandlordRequest)
        {

            var response = await _landlord.AddLandlord(AddLandlordRequest);



            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("AllLandlord")]
        public async Task<ActionResult<ServiceResponse<Landlord>>> GetAllLandlordList()
        {

            var landlords = await _landlord.GetAllLandlords();
            return Ok(landlords);

        }
        [HttpGet("LandlordById/{LandlordId}")]
        public async Task<ActionResult<ServiceResponse<Landlord>>> GetLandlordByID(int LandlordId)
        {
            var landlord = await _landlord.GetLandlordByID(LandlordId);
            return Ok(landlord);
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<ServiceResponse<Landlord>>> UpdateStatus([FromQuery] int LandlordId, [FromQuery] bool status)
        {
            var landlord = await _landlord.UpdateLandlordStatus(LandlordId, status);
            return Ok(landlord);
        }
        [HttpPut("UpdateLandlord")]
        public async Task<ActionResult<ServiceResponse<Landlord>>> UpdateLandlord(UpdateLandlordDto UpdateLandlordDtoRequest)
        {
            var landlord = await _landlord.UpdateLandlord(UpdateLandlordDtoRequest);
            return Ok(landlord);
        }
    }
}
