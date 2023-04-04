using Deals.Dto.Seller;
using Deals.Dto.SocietyBlocksDto;
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
    public class SellerController : ControllerBase
    {
        private readonly Iseller _Iseller;

        public SellerController( Iseller Iseller)
        {
            _Iseller = Iseller;
        }
        [HttpGet("AllSellers")]
        public async Task<ActionResult<ServiceResponse<Seller>>> GetAllSellersList()
        {

            var sellers = await _Iseller.GetAllSellers();
            return Ok(sellers);

        }
        [HttpPost("AddSeller")]
        public async Task<ActionResult<ServiceResponse<Seller>>> AddBlock(AddSellerDto AddSellerRequest)
        {

            var response = await _Iseller.AddSeller(AddSellerRequest);



            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpGet("SellerById/{SellerId}")]
        public async Task<ActionResult<ServiceResponse<Seller>>> GetSeller(int SellerId)
        {
            var Seller = await _Iseller.GetSellerByID(SellerId);
            return Ok(Seller);
        }
        [HttpPut("UpdateSeller")]
        public async Task<ActionResult<ServiceResponse<Seller>>> UpdateSeller(UpdateSeller UpdateSellerDtoRequest)
        {
            var seller = await _Iseller.UpdateSeller(UpdateSellerDtoRequest);
            return Ok(seller);
        }
    }
}
