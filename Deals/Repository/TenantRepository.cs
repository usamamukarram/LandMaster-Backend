using AutoMapper;
using Deals.Data;
using Deals.Dto.Landlord;
using Deals.Dto.Tenant;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class TenantRepository : ITenant
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public TenantRepository(DataContext dataContext, IMapper mapper)
        {
           _dataContext = dataContext;
           _mapper = mapper;
        }
        public async Task<ServiceResponse<GetTenantDto>> AddTenant(AddTenantDto requestTenantDto)
        {
            var response = new ServiceResponse<GetTenantDto>();
            var Block = await _dataContext.societyBlocks.FirstOrDefaultAsync(s => s.BlockId == requestTenantDto.blockId);
            if (Block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == requestTenantDto.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not found";
                return response;
            }
            var PlotSize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == requestTenantDto.PlotSizeId);
            if (PlotSize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }

            var tenant = new Tenant
            {
                TenantName = requestTenantDto.TenantName,
                Contact_number = requestTenantDto.Contact_number,
               

                Budget = requestTenantDto.Budget,
                Category = requestTenantDto.Category,
                Category_type = requestTenantDto.Category_type,
                Comments = requestTenantDto.Comments,
                PlotSize = PlotSize,
                User = user,
                SocietyBlocks = Block

            };

            _dataContext.Add(tenant);
            response.Message = "tenant Added Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<List<GetTenantDto>>> GetAllTenants()
        {
            var response = new ServiceResponse<List<GetTenantDto>>();

            var tenant = await _dataContext.Tenants
                .Include(u => u.User)
                .Include(ps => ps.PlotSize)
                .Include(sb => sb.SocietyBlocks)
                .Include(s => s.SocietyBlocks.society)

                .ToListAsync();
            if (tenant is null)
            {
                response.Success = false;
                response.Message = "No Tenant Found";
            }

            response.Data = tenant.Select(c => _mapper.Map<GetTenantDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<GetTenantDto>> GetTenantByID(int TenantID)
        {
            var response = new ServiceResponse<GetTenantDto>();

            var tenant = await _dataContext.Tenants
                .Where(B => B.Id == TenantID)
                .Include(ps => ps.PlotSize)
                .Include(u => u.User)
                .Include(sb => sb.SocietyBlocks)
                .Include(sb => sb.SocietyBlocks.society)
                .FirstOrDefaultAsync();
            if (tenant is null)
            {
                response.Success = false;
                response.Message = "  Tenant not Found";
            }

            response.Data = _mapper.Map<GetTenantDto>(tenant);
            return response;
        }

        public async Task<ServiceResponse<GetTenantDto>> UpdateTenant(UpdateTenantDto updateTenantRequest)
        {
            var response = new ServiceResponse<GetTenantDto>();
            var tenant = await _dataContext.Tenants.Where(s => s.Id == updateTenantRequest.Id).FirstOrDefaultAsync();
            if (tenant is null)
            {
                response.Success = false;
                response.Message = "Tenant not found";
                return response;
            }
            var block = await _dataContext.societyBlocks.FirstOrDefaultAsync(b => b.BlockId == updateTenantRequest.blockId);
            if (block is null)
            {
                response.Success = false;
                response.Message = "Block not found";
                return response;
            }

            var plotsize = await _dataContext.PlotSizes.FirstOrDefaultAsync(ps => ps.PlotSizeId == updateTenantRequest.PlotSizeId);
            if (plotsize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
                return response;
            }
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserId == updateTenantRequest.UserID);
            if (user is null)
            {
                response.Success = false;
                response.Message = "User Size not found";
                return response;
            }
            tenant.TenantName = updateTenantRequest.TenantName;
            tenant.Contact_number = updateTenantRequest.Contact_number;

            tenant.Budget = updateTenantRequest.Budget;
            tenant.status = updateTenantRequest.status;
            tenant.Category = updateTenantRequest.Category;
            tenant.Category_type = updateTenantRequest.Category_type;
            tenant.Comments = updateTenantRequest.Comments;
            tenant.PlotSize = plotsize;
            tenant.User = user;
            tenant.SocietyBlocks = block;

            response.Message = "Tenant Updated Successfully";
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<GetTenantDto>> UpdateTenantStatus(int TenantID, bool Status)
        {
            var response = new ServiceResponse<GetTenantDto>();
            var tenant = await _dataContext.Tenants.Where(b => b.Id == TenantID).FirstOrDefaultAsync();
            if (tenant is null)
            {
                response.Success = false;
                response.Message = "Tenant not found";
            }
            else
            {

                tenant.status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<GetTenantDto>(tenant);
                response.Message = " status updated successfully";
            }

            return response;
        }
    }
}
