using AutoMapper;
using Deals.Data;
using Deals.Dto.Buyyer;
using Deals.Dto.Landlord;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class LandlordRepository : Ilandlord
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LandlordRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetLandlordDto>> AddLandlord(AddLandlordDto requestLandlordDto)
        {
            var response = new ServiceResponse<GetLandlordDto>();
            var Block = await _dataContext.societyBlocks.FirstOrDefaultAsync(s => s.BlockId == requestLandlordDto.blockId);
            if (Block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == requestLandlordDto.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }
            var PlotSize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == requestLandlordDto.PlotSizeId);
            if (PlotSize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }

            var landlord = new Landlord
            {
                LandLordName = requestLandlordDto.LandlordName,
                Contact_number = requestLandlordDto.Contact_number,
                Plotno = requestLandlordDto.Plotno,

                Demand = requestLandlordDto.Demand,
                Category = requestLandlordDto.Category,
                Category_type = requestLandlordDto.Category_type,
                Comments = requestLandlordDto.Comments,
                PlotSize = PlotSize,
                User = user,
                SocietyBlocks = Block

            };

            _dataContext.Add(landlord);
            response.Message = "Landlord Added Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetLandlordDto>>> GetAllLandlords()

        {
            var response = new ServiceResponse<List<GetLandlordDto>>();

            var landlord = await _dataContext.Landlords
                .Include(u => u.User)
                .Include(ps => ps.PlotSize)
                .Include(sb => sb.SocietyBlocks)
                .Include(s => s.SocietyBlocks.society)

                .ToListAsync();
            if (landlord is null)
            {
                response.Success = false;
                response.Message = "No Landlord Found";
            }

            response.Data = landlord.Select(c => _mapper.Map<GetLandlordDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetLandlordDto>> GetLandlordByID(int LandlordID)
        {
            var response = new ServiceResponse<GetLandlordDto>();

            var Landlord = await _dataContext.Landlords
                .Where(B => B.Id == LandlordID)
                .Include(ps => ps.PlotSize)
                .Include(u => u.User)
                .Include(sb => sb.SocietyBlocks)
                .Include(sb => sb.SocietyBlocks.society)
                .FirstOrDefaultAsync();
            if (Landlord is null)
            {
                response.Success = false;
                response.Message = "  Landlord not Found";
            }

            response.Data = _mapper.Map<GetLandlordDto>(Landlord);
            return response;
        }

        public async Task<ServiceResponse<GetLandlordDto>> UpdateLandlord(UpdateLandlordDto updateLandlordRequest)
        {
            var response = new ServiceResponse<GetLandlordDto>();
            var landlord = await _dataContext.Landlords.Where(s => s.Id == updateLandlordRequest.Id).FirstOrDefaultAsync();
            if (landlord is null)
            {
                response.Success = false;
                response.Message = "Landlord not found";
                return response;
            }
            var block = await _dataContext.societyBlocks.FirstOrDefaultAsync(b => b.BlockId == updateLandlordRequest.blockId);
            if (block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }

            var plotsize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == updateLandlordRequest.PlotSizeId);
            if (plotsize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == updateLandlordRequest.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User Size not found";
                return response;
            }
            landlord.LandLordName = updateLandlordRequest.LandlordName;
            landlord.Contact_number = updateLandlordRequest.Contact_number;
            landlord.Plotno = updateLandlordRequest.Plotno;
            landlord.Demand = updateLandlordRequest.Demand;
            landlord.status = updateLandlordRequest.status;
            landlord.Category = updateLandlordRequest.Category;
            landlord.Category_type = updateLandlordRequest.Category_type;
            landlord.Comments = updateLandlordRequest.Comments;
            landlord.PlotSize = plotsize;
            landlord.User = user;
            landlord.SocietyBlocks = block;

            response.Message = "Landlord Updated Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<GetLandlordDto>> UpdateLandlordStatus(int LandlordID, bool Status)
        {
            var response = new ServiceResponse<GetLandlordDto>();
            var landlord = await _dataContext.Landlords.Where(b => b.Id == LandlordID).FirstOrDefaultAsync();
            if (landlord is null)
            {
                response.Success = false;
                response.Message = "Landlord not found";
            }
            else
            {

                landlord.status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<GetLandlordDto>(landlord);
                response.Message = " status updated successfully";
            }

            return response;
        }
    }
}
