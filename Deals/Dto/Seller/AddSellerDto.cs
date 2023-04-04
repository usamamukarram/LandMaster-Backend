using Deals.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deals.Dto.Seller
{
    public class AddSellerDto
    {
        public string SellerName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Plot_number { get; set; } = string.Empty;
        public string Demand { get; set; } = string.Empty;
        [JsonIgnore]
        public Deals.Models.PlotSize ? PlotSize { get; set; }
        public int PlotSizeId { get; set; } 
        [JsonIgnore]
        public Deals.Models.User ? User { get; set; }
        public int UserID { get; set; }
        [JsonIgnore]
        public SocietyBlocks ? SocietyBlocks { get; set; }
        public int blockId { get; set; }
    }
}
