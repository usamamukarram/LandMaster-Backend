using Deals.Dto.Role;
using Deals.Dto.User;
using Deals.Models;

namespace Deals.Interface
{
    public interface IRole
    {
        Task<ServiceResponse<List<RoleDto>>> GetAllRoles();
        Task<ServiceResponse<RoleDto>> GetRoleById(int RoleId);
    }
}
