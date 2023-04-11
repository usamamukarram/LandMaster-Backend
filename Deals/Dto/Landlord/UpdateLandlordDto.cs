using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deals.Dto.Landlord
{
    public class UpdateLandlordDto
    {
        public int Id { get; set; }
        public string LandlordName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Plotno { get; set; } = string.Empty;
        public string Demand { get; set; } = string.Empty;
        public bool status { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Category_type { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

        [JsonIgnore]
        public Deals.Models.PlotSize? PlotSize { get; set; }
        public int PlotSizeId { get; set; }
        [JsonIgnore]
        public Deals.Models.User? User { get; set; }
        public int UserID { get; set; }
        [JsonIgnore]
        public Deals.Models.SocietyBlocks? SocietyBlocks { get; set; }
        public int blockId { get; set; }
    }
}
