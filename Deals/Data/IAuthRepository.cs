using Deals.Dto.User;
using Deals.Models;

namespace Deals.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<UserDto>> ForgotChangePassword(User userRequest, string password);
        Task<ServiceResponse<UserDto>> ChangePassword(User userRequest, string Oldpassword,string newPassword);
       



    }
}
