using Deals.Dto.Buyyer;
using Deals.Dto.Landlord;
using Deals.Models;

namespace Deals.Interface
{
    public interface Ilandlord
    {
        Task<ServiceResponse<List<GetLandlordDto>>> GetAllLandlords();
        Task<ServiceResponse<GetLandlordDto>> GetLandlordByID(int LandlordID);
        Task<ServiceResponse<GetLandlordDto>> AddLandlord(AddLandlordDto requestLandlordDto);
        Task<ServiceResponse<GetLandlordDto>> UpdateLandlord(UpdateLandlordDto updateLandlordRequest);
        Task<ServiceResponse<GetLandlordDto>> UpdateLandlordStatus(int LandlordID, bool Status);
    }
}
