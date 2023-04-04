using Deals.Dto.User;
using Deals.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Deals.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public AuthRepository( DataContext dataContext, IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string username, string password)
        {
            var response = new ServiceResponse<string>();
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.UserName.ToLower().Equals(username.ToLower()) && u.IsDeleted == false);
            if(user is null)
            {
                response.Success = false;
                response.Message = "User not found";
            }
            else if (!VerifyPasswordHash(password,user.PasswordHash,user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Password";
            }
            else if (user.Verifystatus is false)
            {
                response.Success = false;
                response.Message = "Account not verified yet";
            }
            else
            {
                response.Data = CreateToken(user);
                response.Message = "Successfully Login";
            }
            return response;
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            var response = new ServiceResponse<int>();
            if(await UserExits(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists.";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
           
          
         
            response.Message = "Successfully Registered";
            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<bool> UserExits(string username)
        {
         if( await _dataContext.Users.AnyAsync( u => u.UserName.ToLower() == username.ToLower())) 
            {
                return true;
            
            }
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] PasswordHash ,out byte[] PasswordSalt) {
            using( var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                PasswordSalt = hmac.Key;
                PasswordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //return computedHash.SequenceEqual(PasswordSalt);
            }
        }

        private bool VerifyPasswordHash(string password, byte[] PasswordHash, byte[] PassordSalt)
        {
            using( var hmac = new System .Security.Cryptography.HMACSHA512(PassordSalt)) 
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(PasswordHash);
            }
        }

        private string CreateToken( User user)
        {
            var claims = new List<Claim>
             {
                 new Claim (ClaimTypes.NameIdentifier,user.UserId.ToString()),
                 new Claim (ClaimTypes.Name,user.UserName.ToString()),
                 new Claim (ClaimTypes.Role,user.RoleId.ToString()),
                
                 new Claim ("verifierStatus",user.Verifystatus.ToString()),
                 new Claim("IssueAt",DateTime.Now.AddDays(0).ToString()),
                 new Claim("ExpireAt",DateTime.Now.AddDays(1).ToString()),


                 //new Claim("Issued",DateTime.Now.ToLocalTime()),
                 //new Claim ("Expired",DateTime.Now.AddDays(1).ToLongTimeString()),
             };
            var appSettingToken = _configuration.GetSection("AppSettings:Token").Value;
            if(appSettingToken is null)
            {
                throw new Exception("AppSetting Token is null");
            }

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(appSettingToken));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken((token));
        }

        public async Task<ServiceResponse<UserDto>> ForgotChangePassword(User userRequest, string password)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u=>u.UserName == userRequest.UserName).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not Found.";
                return response;
            }
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;



            response.Message = "Password Changed Successfully";
           
            await _dataContext.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<UserDto>> ChangePassword(User userRequest, string Oldpassword, string newPassword)
        {
            var response = new ServiceResponse<UserDto>();
            var user = await _dataContext.Users.Where(u => u.UserId == userRequest.UserId ).FirstOrDefaultAsync();
            if (user is null)
            {
                response.Success = false;
                response.Message = "User not Found.";
                return response;
            }
            else if (!VerifyPasswordHash(Oldpassword, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Wrong Old Password";
            }
            else if (VerifyPasswordHash(Oldpassword, user.PasswordHash, user.PasswordSalt))
            {
                CreatePasswordHash(newPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;



                response.Message = "Password Changed Successfully";

                await _dataContext.SaveChangesAsync();
            }
            return response;
        }

      
    }
}
