using Deals.Dto.User;
using Deals.Models;
using System.ComponentModel.DataAnnotations;

namespace Deals.Dto.Landlord
{
    public class GetLandlordDto
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
        public Deals.Models.PlotSize PlotSize { get; set; }


        public UserDto User { get; set; }

        public SocietyBlocks SocietyBlocks { get; set; }
    }
}
