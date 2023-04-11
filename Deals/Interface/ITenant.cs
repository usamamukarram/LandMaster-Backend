using Deals.Dto.Buyyer;
using Deals.Dto.Tenant;
using Deals.Models;

namespace Deals.Interface
{
    public interface ITenant
    {
        Task<ServiceResponse<List<GetTenantDto>>> GetAllTenants();
        Task<ServiceResponse<GetTenantDto>> GetTenantByID(int TenantID);
        Task<ServiceResponse<GetTenantDto>> AddTenant(AddTenantDto requestTenantDto);
        Task<ServiceResponse<GetTenantDto>> UpdateTenant(UpdateTenantDto updateTenantRequest);
        Task<ServiceResponse<GetTenantDto>> UpdateTenantStatus(int TenantID, bool Status);
    }
}
