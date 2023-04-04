using Deals.Dto.User;
using Deals.Models;
using System.ComponentModel.DataAnnotations;

namespace Deals.Dto.Seller
{
    public class GetSellerDto
    {
        public int Id { get; set; }
        public string SellerName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Plot_number { get; set; } = string.Empty;
        public string Demand { get; set; } = string.Empty;
        public  Deals.Models.PlotSize PlotSize { get; set; }
        public UserDto User { get; set; }
        public SocietyBlocks SocietyBlocks { get; set; }
    }
}
