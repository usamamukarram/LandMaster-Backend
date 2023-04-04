using Deals.Dto.Role;
using Deals.Dto.Society;
using Deals.Dto.SocietyBlocksDto;
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
    public class SocietyBlocksController : ControllerBase
    {
        private readonly ISocietyBlock _societyBlock;

        public SocietyBlocksController(ISocietyBlock societyBlock)
        {
            _societyBlock = societyBlock;
        }
        [HttpGet("AllBlocks")]
        public async Task<ActionResult<ServiceResponse<SocietyBlocks>>> GetAllBlocksList()
        {

            var Blocks = await _societyBlock.GetAllSocietiesBlock();
            return Ok(Blocks);

        }
        [HttpGet("BlocksById/{blockId}")]
        public async Task<ActionResult<ServiceResponse<SocietyBlocks>>> GetBlockById(int blockId)
        {

            var Block = await _societyBlock.GetBlockById(blockId);
            return Ok(Block);

        }
        [HttpPost("AddBlock")]
        public async Task<ActionResult<ServiceResponse<SocietyBlocks>>> AddBlock(AddBlockDto AddBlockRequest)
        {

            var response = await _societyBlock.AddBlocks(AddBlockRequest);
            


            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("UpdateStatus")]
        public async Task<ActionResult<ServiceResponse<SocietyBlocks>>> UpdateStatus([FromQuery] int BlockID, [FromQuery] bool status)
        {
            var Block = await _societyBlock.UpdateBlockStatus(BlockID, status);
            return Ok(Block);
        }

        [HttpPut("UpdateBlock")]
        public async Task<ActionResult<ServiceResponse<SocietyBlocks>>> UpdateUser(UpdateBlockDto UpdateSocietyDtoRequest)
        {
            var society = await _societyBlock.UpdateBlock(UpdateSocietyDtoRequest);
            return Ok(society);
        }
    }
}
