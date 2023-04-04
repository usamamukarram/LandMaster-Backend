using AutoMapper;
using Deals.Data;
using Deals.Dto.Society;
using Deals.Dto.SocietyBlocksDto;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace Deals.Repository
{
    public class societyBlocksRepository : ISocietyBlock
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public societyBlocksRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SocietyBlocksDto>> AddBlocks(AddBlockDto requestSocietyDto)
        {
            var response = new ServiceResponse<SocietyBlocksDto>();
            var society =  await _dataContext.Societies.FirstOrDefaultAsync(s => s.SocietyId == requestSocietyDto.societyId);
            if(society is null)
            {
                response.Success = false;
                response.Message = "Society not found";
                return response;
            }
            if (await BlockExits(requestSocietyDto.Name))
            {
                response.Success = false;
                response.Message = "Block already exists.";
                return response;

            }
            var Block = new SocietyBlocks
            {
                Name = requestSocietyDto.Name,
                society = society,
            };
           
            _dataContext.Add(Block);
            response.Message = "Block Added Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }
        public async Task<bool>BlockExits(string name)
        {
            if (await _dataContext.societyBlocks.AnyAsync(u => u.Name.ToLower() == name.ToLower()))
            {
                return true;

            }
            return false;
        }
        public async Task<ServiceResponse<List<SocietyBlocksDto>>> GetAllSocietiesBlock()
        {
            var response = new ServiceResponse<List<SocietyBlocksDto>>();

            var societiesBlocks = await _dataContext.societyBlocks.Include(sb=>sb.society).ToListAsync();
            if (societiesBlocks is null)
            {
                response.Success = false;
                response.Message = "No Society Blocks Found";
            }

            response.Data = societiesBlocks.Select(c => _mapper.Map<SocietyBlocksDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<SocietyBlocksDto>> GetBlockById(int blockId)
        {
            var response = new ServiceResponse<SocietyBlocksDto>();

            var societiesBlock = await _dataContext.societyBlocks.Where(b=>b.BlockId == blockId).Include(sb => sb.society).FirstOrDefaultAsync();
            if (societiesBlock is null)
            {
                response.Success = false;
                response.Message = "  Block not Found";
            }

            response.Data = _mapper.Map<SocietyBlocksDto>(societiesBlock);
            return response;
        }

        public async Task<ServiceResponse<SocietyBlocksDto>> UpdateBlock(UpdateBlockDto Request)
        {
            var response = new ServiceResponse<SocietyBlocksDto>();
            var block = await _dataContext.societyBlocks.Where(b => b.BlockId == Request.BlockID).FirstOrDefaultAsync();
            if (block is null) {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }
           
            var society = await _dataContext.Societies.FirstOrDefaultAsync(s => s.SocietyId == Request.societyId);
            if (society is null)
            {
                response.Success = false;
                response.Message = "Society not found";
                return response;
            }
            block.Name = Request.Name;
            block.society = society;
            block.BlockStatus = Request.BlockStatus;
            
           



           // _dataContext.Add(Block);
            response.Message = "Block Updated Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<SocietyBlocksDto>> UpdateBlockStatus(int BlockId, bool Status)
        {
            var response = new ServiceResponse<SocietyBlocksDto>();
            var block = await _dataContext.societyBlocks.Where(u => u.BlockId == BlockId).FirstOrDefaultAsync();
            if (block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
            }
            else
            {

                block.BlockStatus = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<SocietyBlocksDto>(block);
                response.Message = " status updated successfully";
            }

            return response;
        }
    }
}
