namespace Deals.Models
{
    public class Society
    { 
        public int SocietyId { get;set; }
        public string Name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public bool Status { get; set; } = false;

    }
}
