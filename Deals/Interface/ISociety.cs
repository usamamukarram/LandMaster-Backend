using Deals.Dto.Society;
using Deals.Dto.User;
using Deals.Models;

namespace Deals.Interface
{
    public interface ISociety
    {

        Task<ServiceResponse<List<Society>>> GetAllSocieties();
        Task<ServiceResponse<SocietyDto>> GetSocietyByID(int SocietyID);
        Task<ServiceResponse<SocietyDto>> AddSociety(Society requestSocietyDto);
        Task<ServiceResponse<SocietyDto>> UpdateSocietyStatus(int SocietyID, bool Status);
        Task<ServiceResponse<SocietyDto>> UpdateSociety(UpdateSocietyDto SocietyRequest);
    }
}
