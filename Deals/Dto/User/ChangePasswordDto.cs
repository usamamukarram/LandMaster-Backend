namespace Deals.Dto.User
{
    public class ChangePasswordDto
    {
        public int Id { get; set; } 
        public string OldPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
