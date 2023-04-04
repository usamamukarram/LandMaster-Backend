using AutoMapper;
using Azure;
using Deals.Data;
using Deals.Dto.PlotSize;
using Deals.Dto.Role;
using Deals.Dto.Society;
using Deals.Dto.SocietyBlocksDto;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Deals.Repository
{
    public class plotSizeRepository:IPlotSize
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public plotSizeRepository(DataContext  dataContext , IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<PlotSize>> AddPlotSize(PlotSize requestSocietyDto)
        {
            var response = new ServiceResponse<PlotSize>();
            if (await SocietyExits(requestSocietyDto.PlotSizeName))
            {
                response.Success = false;
                response.Message = "Plot Size already exists.";
                return response;

            }

            response.Message = "Plot Size Added Successfully";
            _dataContext.Add(requestSocietyDto);
            await _dataContext.SaveChangesAsync();
            return response;
        }
        public async Task<bool> SocietyExits(string username)
        {
            if (await _dataContext.Societies.AnyAsync(u => u.Name.ToLower() == username.ToLower()))
            {
                return true;

            }
            return false;
        }

        public async Task<ServiceResponse<List<PlotSize>>> GetAllSize()
        {
            var response = new ServiceResponse<List<PlotSize>>();

            var PlotSize = await _dataContext.PlotSizes.ToListAsync();
            if (PlotSize is null)
            {
                response.Success = false;
                response.Message = "No Society Blocks Found";
            }

            response.Data = PlotSize.Select(c => _mapper.Map<PlotSize>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<PlotSize>> GetPlotSizeById(int plotSizeID)
        {
            var response = new ServiceResponse<PlotSize>();
            var plotSize = await _dataContext.PlotSizes.Where(p => p.PlotSizeId == plotSizeID).FirstOrDefaultAsync();
            if (plotSize is null)
            {
                response.Success = false;
                response.Message = " No PlotSize found";
            }
            response.Data = _mapper.Map<PlotSize>(plotSize);
            return response;
        }

        public async Task<ServiceResponse<PlotSize>> UpdatePlotSize(PlotSize PlotSizeRequest)
        {
            var response = new ServiceResponse<PlotSize>();
            var plotSize = await _dataContext.PlotSizes.Where(s => s.PlotSizeId == PlotSizeRequest.PlotSizeId).FirstOrDefaultAsync();
            if (plotSize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
            }

            else
            {
                plotSize.PlotSizeName = PlotSizeRequest.PlotSizeName;
                plotSize.status = PlotSizeRequest.status;


                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<PlotSize>(plotSize);
                response.Message = "Plot Size updated successfully";
            }

            return response;
        }

        public async Task<ServiceResponse<PlotSize>> UpdatePlotSizeStatus(int plotSizeID, bool Status)
        {
            var response = new ServiceResponse<PlotSize>();
            var plotsize = await _dataContext.PlotSizes.Where(u => u.PlotSizeId == plotSizeID).FirstOrDefaultAsync();
            if (plotsize is null)
            {
                response.Success = false;
                response.Message = "Plot Size not found";
            }
            else
            {

                plotsize.status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<PlotSize>(plotsize);
                response.Message = " status updated successfully";
            }

            return response;      }
    }
}
