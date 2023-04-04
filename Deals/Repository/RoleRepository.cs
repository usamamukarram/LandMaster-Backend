using AutoMapper;
using Deals.Data;
using Deals.Dto.Role;
using Deals.Dto.User;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class RoleRepository : IRole
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public RoleRepository(DataContext dataContext,IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public  async Task<ServiceResponse<List<RoleDto>>> GetAllRoles()
        {
            var response = new ServiceResponse<List<RoleDto>>();
            var role = await _dataContext.Roles.ToListAsync();
            if(role is null)
            {
                response.Success = false;
                response.Message = "No roles found";
            }
            response.Data = role.Select(c => _mapper.Map<RoleDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<RoleDto>> GetRoleById(int RoleId)
        {
            var response = new ServiceResponse<RoleDto>();
            var role = await _dataContext.Roles.Where(r => r.RoleId == RoleId).FirstOrDefaultAsync();
            if(role is null)
            {
                response.Success = false;
                response.Message = " No role of id " + RoleId + " found";
            }
            response.Data = _mapper.Map<RoleDto>(role);
            return response;
        }
    }
}
