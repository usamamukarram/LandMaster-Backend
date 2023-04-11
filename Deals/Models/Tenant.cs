using System.ComponentModel.DataAnnotations;

namespace Deals.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string TenantName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Budget { get; set; } = string.Empty;
        public bool status { get; set; } = false;
        public string Category { get; set; } = string.Empty;
        public string Category_type { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public PlotSize PlotSize { get; set; }
        public User User { get; set; }

        public SocietyBlocks SocietyBlocks { get; set; }
    }
}
