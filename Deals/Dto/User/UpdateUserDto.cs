using Deals.Models;
using System.ComponentModel.DataAnnotations;

namespace Deals.Dto.User
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Verifystatus { get; set; }
        public bool IsDeleted { get; set; }

        public int roleId{ get; set; }
    }
}
