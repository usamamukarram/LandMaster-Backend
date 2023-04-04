using System.ComponentModel.DataAnnotations;

namespace Deals.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string SellerName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Plot_number { get; set; } = string.Empty;
        public string Demand { get; set; } = string.Empty;
        public PlotSize PlotSize { get; set; }
        public User User { get; set; }

        public SocietyBlocks SocietyBlocks { get; set; }
       
    }
}
