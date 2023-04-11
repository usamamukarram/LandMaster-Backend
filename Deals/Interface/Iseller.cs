using Deals.Dto.Seller;
using Deals.Dto.Society;
using Deals.Models;

namespace Deals.Interface
{
    public interface Iseller
    {
        Task<ServiceResponse<List<GetSellerDto>>> GetAllSellers();
        Task<ServiceResponse<GetSellerDto>> GetSellerByID(int SellerID);
        Task<ServiceResponse<GetSellerDto>> AddSeller(AddSellerDto requestSellerDto);
        Task<ServiceResponse<GetSellerDto>> UpdateSeller(UpdateSeller updateSellerRequest);
        Task<ServiceResponse<GetSellerDto>> UpdateSellerStatus(int SellerID, bool Status);
    }
}
