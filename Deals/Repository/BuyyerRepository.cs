using AutoMapper;
using Deals.Data;
using Deals.Dto.Buyyer;
using Deals.Dto.Seller;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class BuyyerRepository : IBuyyer
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public BuyyerRepository(DataContext dataContext ,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public  async Task<ServiceResponse<GetBuyyerDto>> AddBuyyer(AddBuyyerDto requestBuyyerDto)
        {
            var response = new ServiceResponse<GetBuyyerDto>();
            var Block = await _dataContext.societyBlocks.FirstOrDefaultAsync(s => s.BlockId == requestBuyyerDto.blockId);
            if (Block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == requestBuyyerDto.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }
            var PlotSize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == requestBuyyerDto.PlotSizeId);
            if (PlotSize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }

            var buyyer = new Buyyer
            {
                BuyerName = requestBuyyerDto.BuyerName,
                Contact_number = requestBuyyerDto.Contact_number,
             
                Budget = requestBuyyerDto.Budget,
                Category = requestBuyyerDto.Category,
                Category_type = requestBuyyerDto.Category_type,
                Comments = requestBuyyerDto.Comments,
                PlotSize = PlotSize,
                User = user,
                SocietyBlocks = Block

            };

            _dataContext.Add(buyyer);
            response.Message = "Buyer Added Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetBuyyerDto>>> GetAllBuyyers()
        {
            var response = new ServiceResponse<List<GetBuyyerDto>>();

            var buyyers = await _dataContext.Buyyers
                .Include(u => u.User)
                .Include(ps => ps.PlotSize)
                .Include(sb => sb.SocietyBlocks)
                .Include(s => s.SocietyBlocks.society)

                .ToListAsync();
            if (buyyers is null)
            {
                response.Success = false;
                response.Message = "No Buyer Found";
            }

            response.Data = buyyers.Select(c => _mapper.Map<GetBuyyerDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetBuyyerDto>> GetBuyyerByID(int BuyyerID)
        {
            var response = new ServiceResponse<GetBuyyerDto>();

            var Buyyer = await _dataContext.Buyyers
                .Where(B => B.Id == BuyyerID)
                .Include(ps => ps.PlotSize)
                .Include(u => u.User)
                .Include(sb => sb.SocietyBlocks)
                .Include(sb => sb.SocietyBlocks.society)
                .FirstOrDefaultAsync();
            if (Buyyer is null)
            {
                response.Success = false;
                response.Message = "  Buyer not Found";
            }

            response.Data = _mapper.Map<GetBuyyerDto>(Buyyer);
            return response;
        }

        public async Task<ServiceResponse<GetBuyyerDto>> UpdateBuyerStatus(int BuyyerID, bool Status)
        {
            var response = new ServiceResponse<GetBuyyerDto>();
            var buyer = await _dataContext.Buyyers.Where(b => b.Id == BuyyerID).FirstOrDefaultAsync();
            if (buyer is null)
            {
                response.Success = false;
                response.Message = "Buyer not found";
            }
            else
            {

                buyer.status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<GetBuyyerDto>(buyer);
                response.Message = " status updated successfully";
            }

            return response;
        }

        public async Task<ServiceResponse<GetBuyyerDto>> UpdateBuyyer(UpdateBuyyerDto updateBuyyerRequest)
        {
            var response = new ServiceResponse<GetBuyyerDto>();
            var Buyyer = await _dataContext.Buyyers.Where(s => s.Id == updateBuyyerRequest.Id).FirstOrDefaultAsync();
            if (Buyyer is null)
            {
                response.Success = false;
                response.Message = "Buyer not found";
                return response;
            }
            var block = await _dataContext.societyBlocks.FirstOrDefaultAsync(b => b.BlockId == updateBuyyerRequest.blockId);
            if (block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }

            var plotsize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == updateBuyyerRequest.PlotSizeId);
            if (plotsize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == updateBuyyerRequest.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User Size not found";
                return response;
            }
            Buyyer.BuyerName = updateBuyyerRequest.BuyerName;
            Buyyer.Contact_number = updateBuyyerRequest.Contact_number;
            Buyyer.Budget = updateBuyyerRequest.Budget;
            Buyyer.status = updateBuyyerRequest.status;
            Buyyer.Category = updateBuyyerRequest.Category;
            Buyyer.Category_type = updateBuyyerRequest.Category_type;
            Buyyer.Comments = updateBuyyerRequest.Comments;
            Buyyer.PlotSize = plotsize;
            Buyyer.User = user;
            Buyyer.SocietyBlocks = block;

            response.Message = "Buyer Updated Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }
    }
}
