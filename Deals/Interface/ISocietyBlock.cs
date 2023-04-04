using Deals.Dto.Role;
using Deals.Dto.Society;
using Deals.Dto.SocietyBlocksDto;
using Deals.Models;

namespace Deals.Interface
{
    public interface ISocietyBlock
    {
        Task<ServiceResponse<List<SocietyBlocksDto>>> GetAllSocietiesBlock();
        Task<ServiceResponse<SocietyBlocksDto>> GetBlockById(int blockId);
        Task<ServiceResponse<SocietyBlocksDto>> AddBlocks(AddBlockDto requestSocietyDto);
        Task<ServiceResponse<SocietyBlocksDto>> UpdateBlockStatus(int BlockId, bool Status);
        Task<ServiceResponse<SocietyBlocksDto>> UpdateBlock(UpdateBlockDto Request);
    }
}
