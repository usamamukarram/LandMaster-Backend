using Deals.Dto.Buyyer;
using Deals.Dto.Seller;
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
    public class BuyyerController : ControllerBase
    {
        private readonly IBuyyer _buyyer;

        public BuyyerController(IBuyyer buyyer)
        {
            _buyyer = buyyer;
        }

        [HttpGet("AllBuyyer")]
        public async Task<ActionResult<ServiceResponse<Buyyer>>> GetAllBuyyerList()
        {

            var buyyers = await _buyyer.GetAllBuyyers();
            return Ok(buyyers);

        }
        [HttpPost("AddBuyyer")]
        public async Task<ActionResult<ServiceResponse<Buyyer>>> AddBuyyer(AddBuyyerDto AddBuyyerRequest)
        {

            var response = await _buyyer.AddBuyyer(AddBuyyerRequest);



            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("BuyyerById/{BuyyerId}")]
        public async Task<ActionResult<ServiceResponse<Buyyer>>> GetBuyyer(int BuyyerId)
        {
            var Buyyer = await _buyyer.GetBuyyerByID(BuyyerId);
            return Ok(Buyyer);
        }
        [HttpPut("UpdateBuyyer")]
        public async Task<ActionResult<ServiceResponse<Buyyer>>> UpdateBuyyer(UpdateBuyyerDto UpdateBuyyerDtoRequest)
        {
            var buyyer = await _buyyer.UpdateBuyyer(UpdateBuyyerDtoRequest);
            return Ok(buyyer);
        }
    }
}
