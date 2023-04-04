using Deals.Dto.Society;
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
    public class SocietyController : ControllerBase
    {
        private readonly ISociety _society;

        public SocietyController(ISociety society)
        {
            _society = society;
        }

        [HttpGet("GetAllSocieties")]
        public async Task<ActionResult<ServiceResponse<Society>>> GetAllSocietiesList()
        {


            var Societies = await _society.GetAllSocieties();
            return Ok(Societies);

        }
        [HttpGet("GetSocietyById/{societyID}")]
        public async Task<ActionResult<ServiceResponse<SocietyDto>>> societyById(int societyID)
        {
            var Society = await _society.GetSocietyByID(societyID);
            return Ok(Society);
        }
        [HttpPost("AddSociety")]
        public async Task<ActionResult<ServiceResponse<SocietyDto>>> AddSociety(AddSocietyDto AddSocietyRequest)
        {

            var response = await _society.AddSociety(
                new Society
                {
                    Name = AddSocietyRequest.Name,
                    City = AddSocietyRequest.City

                });
            ;


            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<ServiceResponse<SocietyDto>>> UpdateStatus([FromQuery] int societyId, [FromQuery] bool status)
        {
            var User = await _society.UpdateSocietyStatus(societyId, status);
            return Ok(User);
        }
        [HttpPut("UpdateSociety")]
        public async Task<ActionResult<ServiceResponse<SocietyDto>>> UpdateUser(UpdateSocietyDto UpdateSocietyDtoRequest)
        {
            var society = await _society.UpdateSociety(UpdateSocietyDtoRequest);
            return Ok(society);
        }
    }
}
