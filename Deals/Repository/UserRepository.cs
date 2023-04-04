using AutoMapper;
using Deals.Data;
using Deals.Dto.User;
using Deals.Interface;
using Deals.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class UserRepository : IUser
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public UserRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<UserDto>> deleteUser(int userId)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userId).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User of Id " + userId + " not found";
            }

            user.IsDeleted = true;
            await _dataContext.SaveChangesAsync();
            response.Data = _mapper.Map<UserDto>(user);
            response.Message = "User deleted successfully";

            return response;
        }

        public async Task<ServiceResponse<List<UserDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<UserDto>>();
            bool is_deleted = false;
            var users = await _dataContext.Users.Where(u => u.IsDeleted == is_deleted).Include(r => r.Role).ToListAsync();
            if (users is null)
               {
                    response.Success = false;
                    response.Message = "No user is Register yet";
               }
               
            response.Data = users.Select(c => _mapper.Map<UserDto>(c)).ToList();
            return response;
        }

        public async Task<ServiceResponse<UserDto>> GetUserById(int userId)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userId && u.IsDeleted== false).Include(r=>r.Role).FirstOrDefaultAsync();
            if(user is null)
            {
                response.Success = false;
                response.Message = "User of Id "+ userId + " not found";
            }
            response.Data = _mapper.Map<UserDto>(user);
            return response;

        }

        public async Task<ServiceResponse<List<UserDto>>> ListOfAllVerifiedUsers()
        {
            var response = new ServiceResponse<List<UserDto>>();
              bool status = true;
            var users = await _dataContext.Users.Where(u=>u.Verifystatus == status && u.IsDeleted == false).Include(r => r.Role).ToListAsync();
            if (users is null)
            {
                response.Success = false;
                response.Message = "No user is Verified yet";
            }

            response.Data = users.Select(c => _mapper.Map<UserDto>(c)).ToList();

            return response;
        }

        public async Task<ServiceResponse<UserDto>> UpateRoleOfUser(int userId, int roleId)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userId && u.IsDeleted == false).Include(r=>r.Role).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User of id " + userId + " not found";
            }
            else
            {
                user.RoleId = roleId;

                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<UserDto>(user);
                response.Message = " User role updated successfully";
            }
            return response;
        }

        public async Task<ServiceResponse<UserDto>> UpdateUser(UpdateUserDto userRequest)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userRequest.Id && u.IsDeleted == false).Include(r=>r.Role).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User of Id " + userRequest.Id + " not found";
            }
            else
            {
                user.UserName = userRequest.Username;
                user.FirstName = userRequest.FirstName;
                user.LastName = userRequest.LastName;
                user.Email = userRequest.Email;
                user.PhoneNumber = userRequest.PhoneNumber;
                user.Notes = userRequest.Notes;
                user.Verifystatus = userRequest.Verifystatus;
                user.IsDeleted = userRequest.IsDeleted;
                user.RoleId = userRequest.roleId;

                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<UserDto>(user);
                response.Message = "User updated successfully";
            }

            return response;
        }

        public async Task<ServiceResponse<UserDto>> UpdateUserVerifierStatus(int userId, bool verifierStatus)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userId && u.IsDeleted== false ).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User of Id " + userId + " not found";
            }
            else
            {

                user.Verifystatus = verifierStatus;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<UserDto>(user);
                response.Message = "Verify status updated successfully";
            }
           
            return response;
        }
    }
}
