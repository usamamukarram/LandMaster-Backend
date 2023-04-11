using Deals.Dto.User;
using Deals.Models;
using System.ComponentModel.DataAnnotations;

namespace Deals.Dto.Buyyer
{
    public class GetBuyyerDto
    {
        public int Id { get; set; }
        public string BuyerName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Budget { get; set; } = string.Empty;
        public bool status { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Category_type { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
        public Deals.Models.PlotSize PlotSize { get; set; }

       
        public UserDto User { get; set; }

        public SocietyBlocks SocietyBlocks { get; set; }
    }
}
