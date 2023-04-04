using Deals.Dto.PlotSize;
using Deals.Dto.Role;
using Deals.Dto.Seller;
using Deals.Dto.Society;
using Deals.Models;

namespace Deals.Interface
{
    public interface IPlotSize
    {
        Task<ServiceResponse<List<PlotSize>>> GetAllSize();
        Task<ServiceResponse<PlotSize>> GetPlotSizeById(int plotSizeID);
        Task<ServiceResponse<PlotSize>> AddPlotSize(PlotSize requestSocietyDto);
        Task<ServiceResponse<PlotSize>> UpdatePlotSizeStatus(int plotSizeID, bool Status);
        Task<ServiceResponse<PlotSize>> UpdatePlotSize(PlotSize SocietyRequest);
    }
}
