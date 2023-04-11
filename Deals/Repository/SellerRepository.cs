using AutoMapper;
using Azure.Core;
using Deals.Data;
using Deals.Dto.Seller;
using Deals.Dto.SocietyBlocksDto;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class SellerRepository:Iseller
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SellerRepository(DataContext dataContext,IMapper mapper)
        {
           _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetSellerDto>> AddSeller(AddSellerDto requestSellerDto)
        {
            var response = new ServiceResponse<GetSellerDto>();
            var Block = await _dataContext.societyBlocks.FirstOrDefaultAsync(s => s.BlockId == requestSellerDto.blockId);
            if (Block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == requestSellerDto.UserID);
            if(user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }
            var PlotSize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == requestSellerDto.PlotSizeId);
            if(PlotSize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }
          
            var seller = new Seller
            {
                SellerName = requestSellerDto.SellerName,
                Contact_number= requestSellerDto.Contact_number,
                Plot_number = requestSellerDto.Plot_number,
                Demand = requestSellerDto.Demand,
                Category = requestSellerDto.Category,
                Category_type = requestSellerDto.Category_type,
                Comments = requestSellerDto.Comments,
                PlotSize = PlotSize,
                User= user,
                SocietyBlocks= Block

            };

            _dataContext.Add(seller);
            response.Message = "Seller Added Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetSellerDto>>> GetAllSellers()
        {
            var response = new ServiceResponse<List<GetSellerDto>>();

            var sellers = await _dataContext.Sellers
                .Include(u=>u.User)
                .Include(ps=>ps.PlotSize)
                .Include(sb=>sb.SocietyBlocks)
                .Include(s=>s.SocietyBlocks.society)
               
                .ToListAsync();
            if (sellers is null)
            {
                response.Success = false;
                response.Message = "No Society Found";
            }

            response.Data = sellers.Select(c => _mapper.Map<GetSellerDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetSellerDto>> GetSellerByID(int SellerID)
        {
            var response = new ServiceResponse<GetSellerDto>();

            var Seller = await _dataContext.Sellers
                .Where(s=>s.Id == SellerID)
                .Include(ps=>ps.PlotSize)
                .Include(u=>u.User)
                .Include(sb=>sb.SocietyBlocks)
                .Include(sb => sb.SocietyBlocks.society)
                .FirstOrDefaultAsync();
            if (Seller is null)
            {
                response.Success = false;
                response.Message = "  Seller not Found";
            }

            response.Data = _mapper.Map<GetSellerDto>(Seller);
            return response;
        }

        public async Task<ServiceResponse<GetSellerDto>> UpdateSeller(UpdateSeller updateSellerRequest)
        {
            var response = new ServiceResponse<GetSellerDto>();
            var Seller = await _dataContext.Sellers.Where(s => s.Id == updateSellerRequest.Id).FirstOrDefaultAsync();
            if (Seller is null)
            {
                response.Success = false;
                response.Message = "Seller not found";
                return response;
            }
            var block = await _dataContext.societyBlocks.FirstOrDefaultAsync(b => b.BlockId == updateSellerRequest.blockId);
            if (block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }

            var plotsize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == updateSellerRequest.PlotSizeId);
            if (plotsize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u=>u.UserId == updateSellerRequest.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User Size not found";
                return response;
            }
            Seller.SellerName = updateSellerRequest.SellerName;
            Seller.Contact_number = updateSellerRequest.Contact_number;
            Seller.Plot_number = updateSellerRequest.Plot_number;
            Seller.Demand = updateSellerRequest.Demand;
            Seller.status = updateSellerRequest.status;
            Seller.Category = updateSellerRequest.Category;
            Seller.Category_type = updateSellerRequest.Category_type;
            Seller.Comments = updateSellerRequest.Comments;
            Seller.PlotSize = plotsize;
            Seller.User = user;
            Seller.SocietyBlocks = block;
            
            response.Message = "Seller Updated Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<GetSellerDto>> UpdateSellerStatus(int SellerID, bool Status)
        {
            var response = new ServiceResponse<GetSellerDto>();
            var seller = await _dataContext.Sellers.Where(s => s.Id == SellerID).FirstOrDefaultAsync();
            if (seller is null)
            {
                response.Success = false;
                response.Message = "Seller not found";
            }
            else
            {

                seller.status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<GetSellerDto>(seller);
                response.Message = " status updated successfully";
            }

            return response;
        }
    }
}
