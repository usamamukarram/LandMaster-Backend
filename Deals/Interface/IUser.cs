using Deals.Dto.User;
using Deals.Models;

namespace Deals.Interface
{
    public interface IUser
    {

        Task<ServiceResponse<List<UserDto>>> GetAllUsers();
        Task<ServiceResponse<UserDto>> GetUserById( int userId);
        Task<ServiceResponse<UserDto>> UpdateUserVerifierStatus(int userId, bool verifierStatus);
        Task<ServiceResponse<UserDto>> UpdateUser(UpdateUserDto userRequest);
        Task<ServiceResponse<UserDto>> UpateRoleOfUser(int userId,  int roleId);
        
        Task<ServiceResponse<List<UserDto>>> ListOfAllVerifiedUsers();
        Task<ServiceResponse<UserDto>> deleteUser(int userId);
        //Task<ServiceResponse<string>> UpdateUser()
    }
}
