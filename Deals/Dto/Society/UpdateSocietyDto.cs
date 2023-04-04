namespace Deals.Dto.Society
{
    public class UpdateSocietyDto
    {
        public int SocietyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool Status { get; set; } 
    }
}

