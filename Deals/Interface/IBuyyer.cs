using Deals.Dto.Buyyer;
using Deals.Dto.Seller;
using Deals.Models;

namespace Deals.Interface
{
    public interface IBuyyer
    {
        Task<ServiceResponse<List<GetBuyyerDto>>> GetAllBuyyers();
        Task<ServiceResponse<GetBuyyerDto>> GetBuyyerByID(int BuyyerID);
        Task<ServiceResponse<GetBuyyerDto>> AddBuyyer(AddBuyyerDto requestBuyyerDto);
        Task<ServiceResponse<GetBuyyerDto>> UpdateBuyyer(UpdateBuyyerDto updateBuyyerRequest);
    }
}
